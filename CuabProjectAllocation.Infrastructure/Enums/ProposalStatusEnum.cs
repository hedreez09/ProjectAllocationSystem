﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Enums
{
    public enum ProposalStatusEnum
    {
        Pending = 1,
        Processing,
        Rejected,
        SupervisorApproved,
        DeanApproved
    }
}
