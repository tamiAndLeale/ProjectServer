using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public  class PortfolioTypeBL: IPortfolioTypeBL
    {
        IPortfolioTypeDL _PortfolioTypeDL;
        //ctor
        public PortfolioTypeBL(IPortfolioTypeDL PortfolioTypeDL)
        {
            _PortfolioTypeDL = PortfolioTypeDL;

        }
        //getAll
        public async Task<List<PortfolioType>> GetallPortfolioTypes()
        {
            return await _PortfolioTypeDL.GetallPortfolioTypes();
        }
        //post
        public async Task<int> AddNewPortfolioType(PortfolioType newportfolio)
        {
            return await _PortfolioTypeDL.AddNewPortfolioType(newportfolio);
        }
        //put
        public async Task<PortfolioType> updatePortfolioType(PortfolioType newportfolio)
        {
            return await _PortfolioTypeDL.updatePortfolioType(newportfolio);

        }
        //delete
        public async Task DeletePortfolioType(int id)
        {
            await _PortfolioTypeDL.DeletePortfolioType(id);
        }

    }
}
