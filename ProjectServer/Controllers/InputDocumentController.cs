using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDocumentController : ControllerBase
    {
        IInputDocumentBL _InputDocumentBL;
        public InputDocumentController(IInputDocumentBL InputDocumentBL)
        {
            _InputDocumentBL = InputDocumentBL;
        }
        [HttpGet("{DocumentTypeId}")]
        public async Task<List<InputDocument>> GetInputDocumentOfDocumentType(int DocumentTypeId)
        {
            return await _InputDocumentBL.GetInputDocumentOfDocumentType(DocumentTypeId);
        }
      //  GET api/<InputDocumentController>/5
        [HttpGet("{portfolioId}/InputDocument")]
        public async Task<List<InputDocument>> GetInputDocumentOfPortfolio(int portfolioId)
        {
            return await _InputDocumentBL.GetInputDocumentOfPortfolio(portfolioId);
        }

        // POST api/<InputDocumentController>
        [HttpPost]
        public async Task<int> AddNewInputDocument([FromBody] InputDocument _InputDocument)
        {

            return await _InputDocumentBL.AddNewInputDocument(_InputDocument);

        }
        // DELETE api/<InputDocumentController>/5
        [HttpDelete("{id}")]
        public async Task DeleteOutputDocument(int id)
        {
            await _InputDocumentBL.DeleteInputDocument(id);
        }
    }
}
