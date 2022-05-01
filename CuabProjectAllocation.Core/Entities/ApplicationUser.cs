using CuabProjectAllocation.Core.Common;
using CuabProjectAllocation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Entities
{
    public class ApplicationUser: Entity<Guid>
    {
        /// <summary>
        /// Username, Application user Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// EmailAddress, Application user email address
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// PasswordHash, User's password hash
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// Account Status, Registration Status
        /// </summary>
        public RegistrationStatusEnum AccountStatus { get; set; }
        /// <summary>
        /// Status, Application User Status
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// LoginFailedCount, Failed login count
        /// </summary>
        public int LoginFailedCount { get; set; }
        /// <summary>
        /// LockoutEnabled, Lockout status after multiple login failure
        /// </summary>
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// UserType, Application user category
        /// </summary>
        public UserType UserType { get; set; }
        /// <summary>
        /// LastLoginTime, Last login Date
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// AccountConfirmationDate, date account was activated
        /// </summary>
        public DateTime? AccountConfirmationDate { get; set; }
    }
}
