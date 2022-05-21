using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class InputDocumentBL: IInputDocumentBL
    {
        //ctor
        IInputDocumentDL _InputDocumentDL;

        public InputDocumentBL(IInputDocumentDL InputDocumenDL)
        {
            _InputDocumentDL = InputDocumenDL;

        }

        //get{id} by PortofolioId 
        public async Task<List<InputDocument>> GetInputDocumentOfPortfolio(int portfolioId)
        {
           return await _InputDocumentDL.GetInputDocumentOfPortfolio(portfolioId);
        }

        //get{id} by DocumentTypeId 
        public async Task<List<InputDocument>> GetInputDocumentOfDocumentType(int DocumentTypeId)
        {
           return await _InputDocumentDL.GetInputDocumentOfDocumentType(DocumentTypeId);
        }

        //post
        public async Task<int> AddNewInputDocument(InputDocument newInputDocument)
        {

            return await _InputDocumentDL.AddNewInputDocument(newInputDocument);
        }

        //delete
        public async Task DeleteInputDocument(int id)
        {
            await _InputDocumentDL.DeleteInputDocument(id);
        }
    }
}
