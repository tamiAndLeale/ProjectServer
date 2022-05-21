using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PortfolioTypeDL: IPortfolioTypeDL
    {
        CTContext ctContext;
        //ctor
        public PortfolioTypeDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }
        //getAll
        public async Task<List<PortfolioType>> GetallPortfolioTypes()
        {

            return await ctContext.PortfolioTypes.ToListAsync();
        }
        //post
        public async Task<int> AddNewPortfolioType(PortfolioType newPortfolioType)
        {

            await ctContext.PortfolioTypes.AddAsync(newPortfolioType);
            await ctContext.SaveChangesAsync();
            return await ctContext.PortfolioTypes.MaxAsync(x => x.Id);
        }
        //put
        public async Task<PortfolioType> updatePortfolioType(PortfolioType newPortfolioType)
        {
            var PortfolioTypeToUpdate = await ctContext.PortfolioTypes.FindAsync(newPortfolioType.Id);
            ctContext.Entry(PortfolioTypeToUpdate).CurrentValues.SetValues(newPortfolioType);
            await ctContext.SaveChangesAsync();
            return newPortfolioType;

        }
        //delete
        public async Task DeletePortfolioType(int id)
        {
            var PortfolioTypeToDelete = await ctContext.PortfolioTypes.FindAsync(id);
            if (PortfolioTypeToDelete != null)
            {
                ctContext.PortfolioTypes.Remove(PortfolioTypeToDelete);
                await ctContext.SaveChangesAsync();
            }
        }

    }
}
