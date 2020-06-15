using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManageAPP.Contracts;
using LeaveManageAPP.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManageAPP.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<LeaveRequest>> FindAll()
        {
            var leaveHistories = await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveHistories;
        }

        public async Task<LeaveRequest> FindById(int id)
        {
            var leaveRequest =await _db.LeaveRequests
                .Include(q => q.RequestingEmployee)
                .Include(q => q.ApprovedBy)
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.LeaveRequests.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> Create(LeaveRequest entity)
        {
            await _db.LeaveRequests.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeId)
        {
            var leaveRequests = await FindAll();
            return leaveRequests.Where(q => q.RequestingEmployeeId == employeeId)
                .ToList();
        }
    }
}
