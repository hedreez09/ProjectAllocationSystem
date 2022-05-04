using CuabProjectAllocation.Infrastructure.Enums;
using System;

namespace CuabProjectAllocation.Infrastructure.Entities
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
              
        ///<summary
        /// Password Salt, hashed password salt
        ///</summary>        
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Account Status, Registration Status
        /// </summary>
        public RegistrationStatusEnum AccountConfirmationStatus { get; set; }
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
