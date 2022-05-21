using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class InputDocumentDL: IInputDocumentDL
    {
        CTContext ctContext;
        //ctor
        public InputDocumentDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }
        //get{id} by PortofolioId 
        public async Task<List<InputDocument>> GetInputDocumentOfPortfolio(int portfolioId)
        {


            return await ctContext.InputDocuments.Where(e => e.PortfolioId == portfolioId).ToListAsync();
        }
        //get{id} by DocumentTypeId 
        public async Task<List<InputDocument>> GetInputDocumentOfDocumentType(int DocumentTypeId)
        {


            return await ctContext.InputDocuments.Where(e => e.DocumentTypeId == DocumentTypeId).ToListAsync();
        }
        //post
        public async Task<int> AddNewInputDocument(InputDocument newInputDocument)
        {

            await ctContext.InputDocuments.AddAsync(newInputDocument);
            await ctContext.SaveChangesAsync();
            return await ctContext.InputDocuments.MaxAsync(x => x.Id);
        }

        //delete
        public async Task DeleteInputDocument(int id)
        {
            var InputDocumentToDelete = await ctContext.InputDocuments.FindAsync(id);
            if (InputDocumentToDelete != null)
            {
                ctContext.InputDocuments.Remove(InputDocumentToDelete);
                await ctContext.SaveChangesAsync();
            }
        }
    }
}
