using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class OutputDocument
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public string Url { get; set; }
        public int PortfolioFolderId { get; set; }
        public string Name { get; set; }
        public bool RequiresApproval { get; set; }
        public DateTime Date { get; set; }
        [JsonIgnore]
        public virtual Portfolio Portfolio { get; set; }
        [JsonIgnore]
        public virtual PortfolioFolder PortfolioFolder { get; set; }
    }
}
