using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPortfolioFolderDL
    {
        Task<List<PortfolioFolder>> GetallFolders(int portfolioTypeId);
    }
}