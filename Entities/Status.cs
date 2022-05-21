using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Status
    {
        public Status()
        {
            Portfolios = new HashSet<Portfolio>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Portfolio> Portfolios { get; set; }
    }
}
