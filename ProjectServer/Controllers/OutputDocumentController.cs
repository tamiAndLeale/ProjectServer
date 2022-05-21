using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutputDocumentController : ControllerBase
    {
        IOutputDocumentBL _OutputDocumentBL;
        public OutputDocumentController(IOutputDocumentBL OutputDocumentBL)
        {
            _OutputDocumentBL = OutputDocumentBL;
        }

        // GET api/<OutputDocumentController>/5
        [HttpGet("{portfolioId}/{folderId}")]
        public async Task<List<OutputDocument>> GetOutputDocumentOfPortfolio(int portfolioId, int folderId)
        {
            return await _OutputDocumentBL.GetOutputDocumentOfPortfolio(portfolioId, folderId);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public async Task<int> AddNewOutputDocument([FromBody] OutputDocument _outputDocument)
        {

            return await _OutputDocumentBL.AddNewOutputDocument(_outputDocument);

        }



        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public async Task DeleteOutputDocument(int id)
        {
            await _OutputDocumentBL.DeleteOutputDocument(id);
        }
    }
}
