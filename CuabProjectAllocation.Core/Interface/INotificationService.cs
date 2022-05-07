﻿using CuabProjectAllocation.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Interface
{
    public interface INotificationService
    {
        Task<bool> SendEmail(string subject, string body, string recepient);
    }
}