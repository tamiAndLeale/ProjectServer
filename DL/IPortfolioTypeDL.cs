using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPortfolioTypeDL
    {
        Task<List<PortfolioType>> GetallPortfolioTypes();
        Task<int> AddNewPortfolioType(PortfolioType newportfolio);
        Task<PortfolioType> updatePortfolioType(PortfolioType newportfolio);
        Task DeletePortfolioType(int id);
    }
}