using CuabProjectAllocation.Core.DTO;
using CuabProjectAllocation.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Interface
{
    public interface INotificationService
    {
        Task<(string subject, string body)> GetEmailTemplate(MailTypeEnum mailType);
        Task<bool> SendEmail(string subject, string body, string recepient);
    }
}
