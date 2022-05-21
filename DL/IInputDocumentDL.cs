using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IInputDocumentDL
    {
        Task<List<InputDocument>> GetInputDocumentOfPortfolio(int portfolioId);
        Task<List<InputDocument>> GetInputDocumentOfDocumentType(int documentTypeId);
        Task<int> AddNewInputDocument(InputDocument newInputDocument);
        Task DeleteInputDocument(int id);
    }
}