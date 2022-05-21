using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioFolderController : ControllerBase
    {
        IPortfolioFolderBL _PortfolioFolderBL;
        IMapper _Imapper;

        public PortfolioFolderController(IPortfolioFolderBL PortfolioFolderBL, IMapper imapper)
        {
            _PortfolioFolderBL = PortfolioFolderBL;
             _Imapper=  imapper; ;

        }
        // GETALL
       // [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // get all foldesrs for portfolio
        [HttpGet("{PortfolioTypeId}")]
        public async Task<List<PortfolioFolderDTO>> GetallFolders(int PortfolioTypeId)
        {
            List<PortfolioFolder> res = await _PortfolioFolderBL.GetallFolders(PortfolioTypeId);
            return _Imapper.Map<List<PortfolioFolder>, List<PortfolioFolderDTO>>(res);
        }

        //// POST api/<FolderController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<FolderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<FolderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
