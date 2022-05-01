using CuabProjectAllocation.Core.Common;
using CuabProjectAllocation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Entities
{
    public class ProposalEntry: Entity<Guid>
    {
        /// <summary>
        /// Name, proposed project/siwes topic
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Batch ID, upload request batch Id
        /// </summary>
        public Guid BatchId { get; set; }
        /// <summary>
        /// FileName, uploaded proposal file name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// FileLocation, uploaded proposal location
        /// </summary>
        public string FileLocation { get; set; }
        /// <summary>
        /// FileExtensiom, uploaded proposal file extension
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// Status, Proposal status 
        /// </summary>
        public ProposalStatusEnum Status { get; set; }
        public ProposalRequest ProposalRequest { get; set; }
        

        public ProposalEntry(Guid Id):
            base(Id)
        {
        }

        private ProposalEntry()
            :base(Guid.NewGuid())
        {
        }

    }
}
