using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IInputDocumentBL
    {
        Task DeleteInputDocument(int id);
        Task<int> AddNewInputDocument(InputDocument inputDocument);
        Task<List<InputDocument>> GetInputDocumentOfPortfolio(int portfolioId);
        Task<List<InputDocument>> GetInputDocumentOfDocumentType(int documentTypeId);
    }
}