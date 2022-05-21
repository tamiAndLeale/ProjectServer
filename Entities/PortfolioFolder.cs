using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class PortfolioFolder
    {
        public PortfolioFolder()
        {
            OutputDocuments = new HashSet<OutputDocument>();
        }

        public int Id { get; set; }
        public int FolderId { get; set; }
        public int PortfolioTypeId { get; set; }

        public virtual Folder Folder { get; set; }
        public virtual PortfolioType portfolioType { get; set; }
        public virtual ICollection<OutputDocument> OutputDocuments { get; set; }
    }
}
