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

        public async Task<ICollection<LeaveAllocation>> FindAll()
        {
            var leaveAllocations = await _db.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include((q => q.Employee))
                .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> FindById(int id)
        {
            var leaveAllocation = await _db.LeaveAllocations
                    .Include(q=>q.LeaveType)
                    .Include(q=>q.Employee)
                    .FirstOrDefaultAsync(q=>q.Id == id);
            return leaveAllocation;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.LeaveAllocations.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> Create(LeaveAllocation entity)
        {
            await _db.LeaveAllocations.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> CheckAllocation(int leaveTypeid, string employeeId)
        {
            var period = DateTime.Now.Year;
            var checkallocations = await FindAll();
                return checkallocations.Where(x => x.LeaveTypeId == leaveTypeid && x.EmployeeId == employeeId && x.Period == period)
                .Any();
        }
        
        public async Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string Id)
        {
            var period = DateTime.Now.Year;
            var getleaveallocationsbyemployee = await FindAll();
            return getleaveallocationsbyemployee.Where(q => q.EmployeeId == Id && q.Period == period).ToList();
        }

        public async Task<LeaveAllocation>  GetLeaveAllocationsByEmployeeAndType(string EmployeeId, int LeaveTypeId)
        {
            var period = DateTime.Now.Year;
            var getleaveallocationbyemployeeandtype = await FindAll();
            return getleaveallocationbyemployeeandtype
                .FirstOrDefault(q => q.EmployeeId == EmployeeId && q.Period == period && q.LeaveTypeId == LeaveTypeId);

        }
    }
}
