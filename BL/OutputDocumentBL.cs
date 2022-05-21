using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class OutputDocumentBL: IOutputDocumentBL
    {
        //ctor
        IOutputDocumentDL _OutputDocumentDL;
       
        public OutputDocumentBL(IOutputDocumentDL OutputDocumenDL)
        {
            _OutputDocumentDL = OutputDocumenDL;

        }
        //get{id} by PortofolioId and folderId
        public async Task<List<OutputDocument>> GetOutputDocumentOfPortfolio(int portfolioId, int folderId)
        {


            return await _OutputDocumentDL.GetOutputDocumentOfPortfolio(portfolioId,folderId);
        }

        //post
        public async Task<int> AddNewOutputDocument(OutputDocument newOutputDocument)
        {

            return await _OutputDocumentDL.AddNewOutputDocument(newOutputDocument);
        }

        //delete
        public async Task DeleteOutputDocument(int id)
        {
            await _OutputDocumentDL.DeleteOutputDocument(id);
        }
    }
}
