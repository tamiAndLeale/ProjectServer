using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public  class PortfolioFolderBL: IPortfolioFolderBL
    {
       
        IPortfolioFolderDL _PortfolioFolderDL;
        //ctor
        public PortfolioFolderBL(IPortfolioFolderDL PortfolioFolderDL)
        {
          
            _PortfolioFolderDL = PortfolioFolderDL;

        }
       

        public async Task<List<PortfolioFolder>> GetallFolders(int PortfolioTypeId)
        {
            return await _PortfolioFolderDL.GetallFolders(PortfolioTypeId);
        }
    }
}
