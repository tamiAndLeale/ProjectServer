using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class InputDocument
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public string Url { get; set; }
        public DateTime DateOfSubmission { get; set; }
        public bool Submitted { get; set; }
        public int DocumentTypeId { get; set; }
        [JsonIgnore]
        public virtual DocumentType DocumentType { get; set; }
        [JsonIgnore]
        public virtual Portfolio Portfolio { get; set; }
    }
}
