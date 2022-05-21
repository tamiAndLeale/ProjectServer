using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IPortfolioTypeBL
    {
        Task<List<PortfolioType>> GetallPortfolioTypes();
        Task<int> AddNewPortfolioType(PortfolioType portfolioType);
        Task<PortfolioType> updatePortfolioType(PortfolioType portfolioType);
        Task DeletePortfolioType(int id);
    }
}