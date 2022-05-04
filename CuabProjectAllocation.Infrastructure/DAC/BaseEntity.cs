using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure
{
    /// <summary>
    /// Class BaseEntity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the created by property/column
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the created by Ip Address property/column
        /// </summary>
        /// <value>The created by Ip address.</value>
        public string CreatedByIp { get; set; }
        /// <summary>
        /// Gets or sets the created date property/column
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the Is Deleted property/column
        /// </summary>
        /// <value>The Is record deleted.</value>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Gets or sets the modified by property/column
        /// </summary>
        /// <value>The modified by.</value>
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Gets or sets the modifier Ip Address property/column
        /// </summary>
        /// <value>The modifier Ip address.</value>
        public string ModifiedByIp { get; set; }
        /// <summary>
        /// Gets or sets the modified date property/column
        /// </summary>
        /// <value>The date modified.</value>
        public DateTime? DateModified { get; set; }
    }
}
