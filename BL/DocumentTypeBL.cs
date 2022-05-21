using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class DocumentTypeBL: IDocumentTypeBL
    {
      IDocumentTypeDL _DocumentTypeDL;
        //ctor
        public DocumentTypeBL(IDocumentTypeDL DocumentTypeDL)//kt gucc
        {
            _DocumentTypeDL = DocumentTypeDL;
            
        }
        //get { user}
        public async Task<List<DocumentType>> GetDocumentTypeByPortfolioTypeId(int id)
        {
            return await _DocumentTypeDL.GetDocumentTypeByPortfolioTypeId(id);
        }
        //get 
        public async Task<List<DocumentType>> GetallDocumentType()
        {
            return await _DocumentTypeDL.GetallDocumentType();
        }
        //post
        public async Task<int> AddNewDocumentType(DocumentType newDocumentType)
        {
            return await _DocumentTypeDL.AddNewDocumentType(newDocumentType);
        }
        //put
        public async Task<DocumentType> updateDocumentType(DocumentType newDocumentType)
        {
            return await _DocumentTypeDL.updateDocumentType(newDocumentType);

        }
        //delete
        public async Task DeleteDocumentType(int id)
        {
            await _DocumentTypeDL.DeleteDocumentType(id);
        }
    }
}
