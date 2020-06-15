using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManageAPP.Data;

namespace LeaveManageAPP.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        Task<bool> CheckAllocation(int leaveTypeid , string employeeId);
        Task<ICollection<LeaveAllocation>> GetLeaveAllocationsByEmployee(string employeeId);
        Task<LeaveAllocation> GetLeaveAllocationsByEmployeeAndType(string employeeId, int leaveTypeId);
    }
}
