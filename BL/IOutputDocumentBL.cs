using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IOutputDocumentBL
    {

        Task<List<OutputDocument>> GetOutputDocumentOfPortfolio(int portfolioId, int folderId);
        Task<int> AddNewOutputDocument(OutputDocument newOutputDocument);
        Task DeleteOutputDocument(int id);
    }
}