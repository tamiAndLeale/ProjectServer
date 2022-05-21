using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OutputDocumentDL: IOutputDocumentDL
    {
        CTContext ctContext;
        //ctor
        public OutputDocumentDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }
        //get{id} by PortofolioId and folderId
        public async Task<List<OutputDocument>> GetOutputDocumentOfPortfolio(int portfolioId, int folderId)
        {


            return await ctContext.OutputDocuments.Where(e => e.PortfolioId== portfolioId&& e.PortfolioFolderId== folderId).ToListAsync();
        }
        
        //post
        public async Task<int> AddNewOutputDocument(OutputDocument newOutputDocument)
        {

            await ctContext.OutputDocuments.AddAsync(newOutputDocument);
            await ctContext.SaveChangesAsync();
            return await ctContext.OutputDocuments.MaxAsync(x => x.Id);
        }
      
        //delete
        public async Task DeleteOutputDocument(int id)
        {
            var OutputDocumentToDelete = await ctContext.OutputDocuments.FindAsync(id);
            if (OutputDocumentToDelete != null)
            {
                ctContext.OutputDocuments.Remove(OutputDocumentToDelete);
                await ctContext.SaveChangesAsync();
            }
        }
    }
}
