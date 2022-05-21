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
    public class DocumentTypeController : ControllerBase
    {

        IDocumentTypeBL _DocumentTypeBL;
        public DocumentTypeController(IDocumentTypeBL DocumentTypeBL)//
        {
            _DocumentTypeBL = DocumentTypeBL;
        }
      //  GET: api/<DocumentTypeController>
        [HttpGet]
        public async Task<List<DocumentType>> GetallDocumentType()
        {
            return await _DocumentTypeBL.GetallDocumentType();
        }

       // GET api/<DocumentTypeController>/5 
        [HttpGet("{id}")]
        public async Task<List<DocumentType>> GetDocumentTypeByPortfolioTypeId(int id)
        {

            return await _DocumentTypeBL.GetDocumentTypeByPortfolioTypeId(id);
        }
//  POST api/<DocumentTypeController>
        [HttpPost]
        public async Task<int> AddNewDocumentType([FromBody] DocumentType _DocumentType)
        {

            return await _DocumentTypeBL.AddNewDocumentType(_DocumentType);

        }

     //   PUT api/<DocumentTypeController>/5
        [HttpPut("{id}")]
        public async Task<DocumentType> updateDocumentType([FromBody] DocumentType _DocumentType)
        {
            return await _DocumentTypeBL.updateDocumentType(_DocumentType);
        }

       // DELETE api/<DocumentTypeController>/5
        [HttpDelete("{id}")]
        public async Task DeleteDocumentType(int id)
        {
            await _DocumentTypeBL.DeleteDocumentType(id);
        }
    }
}
