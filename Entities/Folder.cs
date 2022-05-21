using System;
using System.Collections.Generic;

#nullable disable

namespace Entities
{
    public partial class Folder
    {
        public Folder()
        {
            PortfolioFolders = new HashSet<PortfolioFolder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PortfolioFolder> PortfolioFolders { get; set; }
    }
}
