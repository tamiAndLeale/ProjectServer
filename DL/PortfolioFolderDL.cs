using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
  public  class PortfolioFolderDL: IPortfolioFolderDL
    {
        CTContext ctContext;
        //ctor
        public PortfolioFolderDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }


        public async Task<List<PortfolioFolder>> GetallFolders(int portfolioTypeId)
        {
            return await ctContext.PortfolioFolders.Include ( a => a.Folder) .Where (sorce=>sorce.Folder.Id==sorce.FolderId).Where(e => e.PortfolioTypeId == portfolioTypeId).ToListAsync();
        }
    }
    }

