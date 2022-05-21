using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class PortfolioBL: IPortfolioBL
    {
        IPortfolioDL _PortfolioDL;
        //constractor
        public PortfolioBL(IPortfolioDL PortfolioDL)
        {
            _PortfolioDL = PortfolioDL;
            
        }
        //get { user}
        public async Task<List<Portfolio>> GetPortfoliosOfUser(int id)
        {
            return await _PortfolioDL.GetPortfoliosOfUser( id);
        }
        //get 
        public async Task<List<Portfolio>> GetallPortfolios()
        {
            return await _PortfolioDL.GetallPortfolios();
        }
        //post
        public async Task<int> AddNewPortfolio(Portfolio newportfolio)
        {
            return await _PortfolioDL.AddNewPortfolio(newportfolio);
        }
        //put
        public async Task<Portfolio> updatePortfolio(Portfolio newportfolio)
        {
            return await _PortfolioDL.updatePortfolio(newportfolio);

        }
        //delete
        public async Task DeletePortfolio(int id)
        {
            await _PortfolioDL.DeletePortfolio(id);
        }

        public Task<List<Portfolio>> GetPortfoliosOfUser()
        {
            throw new NotImplementedException();
        }
    }
}
