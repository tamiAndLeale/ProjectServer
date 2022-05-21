using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            InputDocuments = new HashSet<InputDocument>();
            OutputDocuments = new HashSet<OutputDocument>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfOpen { get; set; }
        public DateTime Dedline { get; set; }
        public int StatusId { get; set; }
        
        public virtual Status Status { get; set; }

        public virtual PortfolioType Type { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<InputDocument> InputDocuments { get; set; }
        [JsonIgnore]
        public virtual ICollection<OutputDocument> OutputDocuments { get; set; }
    }
}
