using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
     public class PortfolioDL:IPortfolioDL
    {
        CTContext ctContext;
        //constructor
        public PortfolioDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }
        //get{id}
        public async Task<List<Portfolio>> GetPortfoliosOfUser(int id)
        {
            return await ctContext.Portfolio.Include(a => a.Status).Include(a => a.Type).Where(e => e.UserId == id).ToListAsync();
        }
        //gets
        public async Task<List<Portfolio>> GetallPortfolios()
        {

            return await ctContext.Portfolio.Include(a => a.Status).Include(a => a.Type).ToListAsync();
        }
        //post
        public async Task<int> AddNewPortfolio(Portfolio newportfolio)
        {

            await ctContext.Portfolio.AddAsync(newportfolio);
             await ctContext.SaveChangesAsync();
            return await ctContext.Portfolio.MaxAsync(x => x.Id);
        }
        //put
        public async Task<Portfolio> updatePortfolio(Portfolio newportfolio)
        {
            var PortfolioToUpdate = await ctContext.Portfolio.FindAsync(newportfolio.Id);
            ctContext.Entry(PortfolioToUpdate).CurrentValues.SetValues(newportfolio);
            await ctContext.SaveChangesAsync();
            return newportfolio;

        }
        //delete
        public async Task DeletePortfolio(int id)
        {
            var PortfolioToDelete = await ctContext.Portfolio.FindAsync(id);
            if (PortfolioToDelete!=null)
            {
               ctContext.Portfolio.Remove(PortfolioToDelete);
                await ctContext.SaveChangesAsync();
            }
        }

     
    }
}
