using CuabProjectAllocation.Core.Common;
using CuabProjectAllocation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Core.Entities
{
    public class ProposalRequest: Entity<Guid>
    {
        /// <summary>
        /// Matric Number, the matric number of the student
        /// </summary>
        public string MatricNumber { get; set; }
        /// <summary>
        /// Status, Siwes/Project Proposal Status
        /// </summary>
        public ProposalStatusEnum  Status { get; set; }
        /// <summary>
        /// Request Type, proposal request type (Siwes/Project)
        /// </summary>
        public ProposalTypeEnum RequestType { get; set; }

        public List<ProposalEntry> proposalEntries { get; set; }

        public ProposalRequest(Guid Id):
            base(Id)
        {
        }

        private ProposalRequest()
            :base(Guid.NewGuid())
        { }
    }
}
