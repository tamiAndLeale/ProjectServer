using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public  class PortfolioDTO
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public DateTime DateOfOpen { get; set; }
        public DateTime Dedline { get; set; }
        public int PortfolioTypeId { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }
    }
}
