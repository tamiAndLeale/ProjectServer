using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPortfolioDL
    {
        
        Task<List<Portfolio>> GetPortfoliosOfUser(int id);
        Task<List<Portfolio>> GetallPortfolios();
        
        Task<int> AddNewPortfolio(Portfolio newportfolio);
        Task<Portfolio> updatePortfolio(Portfolio newportfolio);
        Task DeletePortfolio(int id);
    }
}