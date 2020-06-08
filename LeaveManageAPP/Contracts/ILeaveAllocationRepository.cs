using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManageAPP.Data;

namespace LeaveManageAPP.Contracts
{
    public interface ILeaveAllocationRepository : IRepositoryBase<LeaveAllocation>
    {
        bool CheckAllocation(int leaveTypeid , string employeeId);
        ICollection<LeaveAllocation> GetLeaveAllocationsByEmployee(string Id);
    }
}
