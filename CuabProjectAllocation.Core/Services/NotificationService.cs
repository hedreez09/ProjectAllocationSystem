using CuabProjectAllocation.Core.Interface;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;
using CuabProjectAllocation.Core.Util;
using MailKit.Net.Smtp;
using CuabProjectAllocation.Infrastructure.DAC;
using CuabProjectAllocation.Infrastructure.Entities;
using CuabProjectAllocation.Infrastructure.Enums;

namespace CuabProjectAllocation.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IOptions<AppSettings> _appSettings;
        private readonly IEntityRepository<EmailTemplate> _emailRepository;

        public NotificationService(IOptions<AppSettings> appSettings, IEntityRepository<EmailTemplate> emailRepository)
        {
            _appSettings = appSettings;
            _emailRepository = emailRepository;
        }

        public async Task<(string subject, string body)> GetEmailTemplate(MailTypeEnum mailType)
        {
            string sub = "";
            string bdy = "";
            var result = await _emailRepository.GetByAsync(x => x.MailType == mailType);
            
            sub = result?.Subject;
            bdy = result?.Body;
            
            return (sub, bdy);            
        }

        public async Task<bool> SendEmail(string subject, string body, string recepient)
        {
            bool result = false;

            try
            {
                string fromAddress = _appSettings.Value.CuabSmtpEmail;
                string serverAddress = _appSettings.Value.CuabSmtpServer;
                string username = _appSettings.Value.CuabSmptUsername;
                string password = _appSettings.Value.CuabSmtpPassword;
                int port = Convert.ToInt32(_appSettings.Value.CuabSmtpPort);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(fromAddress, fromAddress));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body,
                };

                if (_appSettings.Value.Dev_Env == "TEST")
                    return true;

                using(var client = new SmtpClient())
                {
                    client.Timeout = 30000;
                    await client.ConnectAsync(serverAddress, port, true);
                    
                    //authenticate
                    await client.AuthenticateAsync(username, password);
                    
                    await client.SendAsync(message);
                    result = true;

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                result = false;
            }

            return result;
        }
    }
}
