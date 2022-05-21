using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IDocumentTypeDL
    {
        Task<List<DocumentType>> GetDocumentTypeByPortfolioTypeId(int id);
        Task<List<DocumentType>> GetallDocumentType();
        Task<int> AddNewDocumentType(DocumentType newDocumentType);
        Task<DocumentType> updateDocumentType(DocumentType newDocumentType);
        Task DeleteDocumentType(int id);
    }
}