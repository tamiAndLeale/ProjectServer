using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IPortfolioFolderBL
    {
        Task<List<PortfolioFolder>> GetallFolders(int PortfolioTypeId);
    
    }
}