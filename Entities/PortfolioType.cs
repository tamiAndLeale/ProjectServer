using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class PortfolioType
    {
        public PortfolioType()
        {
            DocumentTypes = new HashSet<DocumentType>();
            PortfolioFolders = new HashSet<PortfolioFolder>();
            Portfolios = new HashSet<Portfolio>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<DocumentType> DocumentTypes { get; set; }
        [JsonIgnore]
        public virtual ICollection<PortfolioFolder> PortfolioFolders { get; set; }
        [JsonIgnore]
        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}
