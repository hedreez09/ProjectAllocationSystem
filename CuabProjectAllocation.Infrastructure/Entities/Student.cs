using CuabProjectAllocation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.Entities
{
    public class Student: Entity<Guid>
    {
        /// <summary>
        /// FullName, name of student
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Matric Number, Student Matric Number
        /// </summary>
        public string MatricNumber { get; set; }
        /// <summary>
        /// Email, Student Email Address
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Phone Number, Student mobile number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gender, Student Gender
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Department, Student department
        /// </summary>
        public string Department { get; set; }

    }
}
