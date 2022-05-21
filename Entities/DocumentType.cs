using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            InputDocuments = new HashSet<InputDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PortfolioTypeId { get; set; }
        public bool Required { get; set; }
        public bool RequiredArchitecturalApproval { get; set; }

        public virtual PortfolioType PortfolioType { get; set; }
        public virtual ICollection<InputDocument> InputDocuments { get; set; }
    }
}
