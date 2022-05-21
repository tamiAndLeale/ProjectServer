using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class PortfolioFolderDTO
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public int PortfolioTypeId { get; set; }
        public string Name { get; set; }

    }
}
