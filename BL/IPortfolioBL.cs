using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IPortfolioBL
    {
        Task<List<Portfolio>> GetPortfoliosOfUser(int id);
        Task<List<Portfolio>> GetallPortfolios();
        Task<int> AddNewPortfolio(Portfolio newportfolio);
        Task<Portfolio> updatePortfolio(Portfolio portfolio);
      
        Task DeletePortfolio(int id);
       
    }
}