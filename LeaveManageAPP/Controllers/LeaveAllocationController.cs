using System;
using System.Collections.Generic;
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

namespace LeaveManageAPP.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveTypeRepository _leaverepo;
        private readonly ILeaveAllocationRepository _leaveAllocationrepo;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        public LeaveAllocationController(IMapper mapper, ILeaveAllocationRepository leaveAllocationrepo, ILeaveTypeRepository leaverepo, UserManager<Employee> userManager)
        {
            _mapper = mapper;
            _leaveAllocationrepo = leaveAllocationrepo;
            _leaverepo = leaverepo;
            _userManager = userManager;
        }

        // GET: LeaveAllocationController
        public async Task<ActionResult> Index()
        {
            var leavetypes = await _leaverepo.FindAll();
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leavetypes.ToList());
            var model = new CreateLeaveAllocationVM
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdate = 0
            };
            return View(model);
        }

        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var employee = _mapper.Map<EmployeeVM>(await _userManager.FindByIdAsync(id));
            var alloctions = _mapper.Map<List<LeaveAllocationVM>>(await _leaveAllocationrepo.GetLeaveAllocationsByEmployee(id));
            var model = new ViewAllocationsVM
            {
                Employee = employee, LeaveAllocations = alloctions
            };
            return View(model);
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leaveAllocations = await _leaveAllocationrepo.FindById(id);
            var model = _mapper.Map<EditLeaveAllocationVM>(leaveAllocations);
            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditLeaveAllocationVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var record = await _leaveAllocationrepo.FindById(model.Id);
                record.NumberOfDays = model.NumberOfDays;
                var isSuccess = await _leaveAllocationrepo.Update(record);
                if (!isSuccess)
                {
                    ModelState.AddModelError("","Something went wrong");
                    return View(model);
                }
                return RedirectToAction(nameof(Details),new {id=model.EmployeeId});
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
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

        public async Task<ActionResult> SetLeave(int id)
        {
            var leaveType = await _leaverepo.FindById(id);  
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            foreach (var emp in employees)
            {
                if (await _leaveAllocationrepo.CheckAllocation(id,emp.Id))
                    continue;
                var allocation = new LeaveAllocationVM
                {
                    DateCreated = DateTime.Now,
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year
                };
                var leaveAllocation = _mapper.Map<LeaveAllocation>(allocation);
               await _leaveAllocationrepo.Create(leaveAllocation);
            }

            return RedirectToAction(nameof(Index));

        }

        public async Task<ActionResult> ListEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            var model = _mapper.Map<List<EmployeeVM>>(employees);
            return View(model);
        }
    }
}
