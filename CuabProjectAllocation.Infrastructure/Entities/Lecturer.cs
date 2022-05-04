using CuabProjectAllocation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Entities
{
    public class Lecturer: Entity<Guid>
    {
        /// <summary>
        /// StaffId, Lecturers Staff Id
        /// </summary>
        public string StaffId { get; set; }
        /// <summary>
        /// FullName, Staff fullname
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Gender, Staff gender property
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Department, Staff' department
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// Email, Staff' Email Address
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phone Number, Staff mobile number
        /// </summary>
        public string PhoneNumber { get; set; }

        public Lecturer(Guid Id):
            base(Id)
        {
        }

        private Lecturer()
            : base(Guid.NewGuid()) { }
    }
}
