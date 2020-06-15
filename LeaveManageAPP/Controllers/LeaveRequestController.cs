using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManageAPP.Contracts;
using LeaveManageAPP.Data;
using LeaveManageAPP.Models;
using LeaveManageAPP.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace LeaveManageAPP.Controllers
{
    [Authorize]
    public class LeaveRequestController : Controller
    {
        // GET: LeaveRequestController
        private readonly ILeaveRequestRepository _leaverequestrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationrepo;
        public LeaveRequestController(ILeaveRequestRepository leaverequestrepo, IMapper mapper, UserManager<Employee> userManager, ILeaveTypeRepository leaveTypeRepository, ILeaveAllocationRepository leaveAllocationrepo)
        {
            _leaverequestrepo = leaverequestrepo;
            _mapper = mapper;
            _userManager = userManager;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationrepo = leaveAllocationrepo;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var leaverequests = await _leaverequestrepo.FindAll();
            var leaverequestModel = _mapper.Map<List<LeaveRequestVM>>(leaverequests);
            var model = new AdminLeaveRequestVM
            {
                TotalRequests = leaverequestModel.Count,
                ApprovedRequests = leaverequestModel.Count(q => q.Approved == true),
                PendingRequests = leaverequestModel.Count(q => q.Approved == null),
                RejectedRequests = leaverequestModel.Count(q => q.Approved == false),
                LeaveRequests = leaverequestModel
            };
            return View(model);
        }

        // GET: LeaveRequestController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var leaveRequest = await _leaverequestrepo.FindById(id);
            var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
            return View(model);
        }

        // GET: LeaveRequestController/Create
        public async Task<ActionResult> Create()
        {
            var leaveTypes =await _leaveTypeRepository.FindAll();
            var leaveTypeItems = leaveTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var modal = new CreateLeaveRequestVM
            {
                LeaveTypes = leaveTypeItems
            };
            return View(modal);
        }

        // POST: LeaveRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestVM modal)
        {

            try
            {
                var startDate = Convert.ToDateTime(modal.StartDate);
                var endDate = Convert.ToDateTime(modal.EndDate);
                var leaveTypes = await _leaveTypeRepository.FindAll();
                var leaveTypeItems =  leaveTypes.Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                modal.LeaveTypes = leaveTypeItems;

                if (!ModelState.IsValid)
                {
                    return View(modal);
                }

                if (DateTime.Compare(startDate, endDate) > 1)
                {
                    ModelState.AddModelError("", "Start Date cannot be further in the future than the End Date");
                    return View(modal);
                }

                var employee = await _userManager.GetUserAsync(User);
                var allocation = await _leaveAllocationrepo.GetLeaveAllocationsByEmployeeAndType(employee.Id, modal.LeaveTypeId);
                int daysRequested = (int)(endDate - startDate).TotalDays;

                if (daysRequested > allocation.NumberOfDays)
                {
                    ModelState.AddModelError("", "You Do Not Sufficient Days For This Request");
                    return View(modal);
                }

                var leaveRequestModel = new LeaveRequestVM
                {
                    RequestingEmployeeId = employee.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    Approved = null,
                    DateRequested = DateTime.Now,
                    DateActioned = DateTime.Now,
                    LeaveTypeId = modal.LeaveTypeId,
                    RequestComments = modal.RequestComments
                };

                var leaveRequest = _mapper.Map<LeaveRequest>(leaveRequestModel);
                var isSuccess = await _leaverequestrepo.Create(leaveRequest);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong with submitting your record");
                    return View(modal);
                }

                 return RedirectToAction("MyLeave");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong");
                Console.WriteLine(ex);
                return View(modal);
            }
        }

        // GET: LeaveRequestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveRequestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> ApproveRequest(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var leaveRequest = await _leaverequestrepo.FindById(id);
                var employeeId = leaveRequest.RequestingEmployeeId;
                var leaveTypeId = leaveRequest.LeaveTypeId;
                var allocation = await _leaveAllocationrepo.GetLeaveAllocationsByEmployeeAndType(employeeId,leaveTypeId);
                int daysRequested = (int) (leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                leaveRequest.Approved = true;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;
                await _leaverequestrepo.Update(leaveRequest);

                await _leaveAllocationrepo.Update(allocation);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong..!!");
                Console.WriteLine(ex);
                return RedirectToAction("Index");

            }

        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var leaveRequest = await _leaverequestrepo.FindById(id);
                leaveRequest.Approved = false;
                leaveRequest.ApprovedById = user.Id;
                leaveRequest.DateActioned = DateTime.Now;

                await _leaverequestrepo.Update(leaveRequest);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong..!!");
                Console.WriteLine(ex);
                return RedirectToAction("Index");

            }
        }

        public async Task<ActionResult> MyLeave()
        {
            var employee = await _userManager.GetUserAsync(User);
            var employeeId = employee.Id;
            var employeeAllocations = await _leaveAllocationrepo.GetLeaveAllocationsByEmployee(employeeId);
            var employeeRequests =await  _leaverequestrepo.GetLeaveRequestsByEmployee(employeeId);

            var employeeAllocationsModel = _mapper.Map<List<LeaveAllocationVM>>(employeeAllocations);
            var employeeRequestModel = _mapper.Map<List<LeaveRequestVM>>(employeeRequests);
            var model =  new EmployeeLeaveRequestViewVM
            {
                LeaveAllocations = employeeAllocationsModel,
                LeaveRequests = employeeRequestModel
            };
            return View(model);
        }

        public async Task<ActionResult> CancelRequest(int id)
        {
            var leaveRequest = await _leaverequestrepo.FindById(id);
            leaveRequest.Cancelled = true;
            await _leaverequestrepo.Update(leaveRequest);
            return RedirectToAction("MyLeave");

        }
    }
}
