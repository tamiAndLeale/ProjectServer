using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IDocumentTypeBL
    {
    
        Task<List<DocumentType>> GetallDocumentType();
        Task<List<DocumentType>> GetDocumentTypeByPortfolioTypeId(int id);
        Task<int> AddNewDocumentType(DocumentType documentType);
        Task<DocumentType> updateDocumentType(DocumentType documentType);
        Task DeleteDocumentType(int id);
    }
}