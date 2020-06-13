using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManageAPP.Contracts;
using LeaveManageAPP.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManageAPP.Repository
{
    public class LeaveAllocationRepository:ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocations = _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include((q => q.Employee))
                .ToList();
            return leaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            var leaveAllocation = _db.LeaveAllocations
                    .Include(q=>q.LeaveType)
                    .Include(q=>q.Employee)
                    .FirstOrDefault(q=>q.Id == id);
            return leaveAllocation;
        }

        public bool isExists(int id)
        {
            var isExists = _db.LeaveAllocations.Any(q => q.Id == id);
            return isExists;
        }

        public bool Create(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Add(entity);
            return Save();
        }

        public bool Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return Save();
        }

        public bool Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool CheckAllocation(int leaveTypeid, string employeeId)
        {
            var period = DateTime.Now.Year;
            return FindAll().
                Where(x => x.LeaveTypeId == leaveTypeid && x.EmployeeId == employeeId && x.Period == period)
                .Any();
        }

        public ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string Id)
        {
            var period = DateTime.Now.Year;
            return FindAll().Where(q => q.EmployeeId == Id && q.Period == period).ToList();
        }

        public LeaveAllocation  GetLeaveAllocationsByEmployeeAndType(string EmployeeId, int LeaveTypeId)
        {
            var period = DateTime.Now.Year;
            return FindAll()
                .FirstOrDefault(q => q.EmployeeId == EmployeeId && q.Period == period && q.LeaveTypeId == LeaveTypeId);

        }
    }
}
