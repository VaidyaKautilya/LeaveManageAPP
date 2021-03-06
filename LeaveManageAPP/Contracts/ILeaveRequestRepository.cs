﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaveManageAPP.Data;

namespace LeaveManageAPP.Contracts
{
    public interface ILeaveRequestRepository:IRepositoryBase<LeaveRequest>
    {
        Task<ICollection<LeaveRequest>> GetLeaveRequestsByEmployee(string employeeId);
    }
}
