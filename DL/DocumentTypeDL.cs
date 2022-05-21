using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class DocumentTypeDL : IDocumentTypeDL
    {
        CTContext ctContext;
        //CTOR
        public DocumentTypeDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }
        //get{id}
        public async Task<List<DocumentType>> GetDocumentTypeByPortfolioTypeId(int id)
        {


            return await ctContext.DocumentTypes.Where(e => e.PortfolioTypeId == id).ToListAsync();
        }
        //get
        public async Task<List<DocumentType>> GetallDocumentType()
        {

            return await ctContext.DocumentTypes.ToListAsync();
            //throw new Exception();
        }
        //post
        public async Task<int> AddNewDocumentType(DocumentType newDocumentType)
        {

            await ctContext.DocumentTypes.AddAsync(newDocumentType);
            await ctContext.SaveChangesAsync();
            return await ctContext.DocumentTypes.MaxAsync(x => x.Id);
        }
        //put
        public async Task<DocumentType> updateDocumentType(DocumentType newDocumentType)
        {
            var DocumentTypeToUpdate = await ctContext.DocumentTypes.FindAsync(newDocumentType.Id);
            ctContext.Entry(DocumentTypeToUpdate).CurrentValues.SetValues(newDocumentType);
            await ctContext.SaveChangesAsync();
            return newDocumentType;

        }
        //delete
        public async Task DeleteDocumentType(int id)
        {
            var DocumentTypeToDelete = await ctContext.DocumentTypes.FindAsync(id);
            if (DocumentTypeToDelete != null)
            {
                ctContext.DocumentTypes.Remove(DocumentTypeToDelete);
                await ctContext.SaveChangesAsync();
            }
        }


    }
}
