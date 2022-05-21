using BL;
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
    public class PortfolioTypeController : ControllerBase
    {
        IPortfolioTypeBL _PortfolioTypeBL;
        public PortfolioTypeController(IPortfolioTypeBL PortfolioTypeBL)
        {
            _PortfolioTypeBL = PortfolioTypeBL;
        }


        // GET: api/<PortfolioTypeController>
        [HttpGet]
        public async Task<List<PortfolioType>> GetallPortfolioTypes()
        {

            return await _PortfolioTypeBL.GetallPortfolioTypes();
        }



        // GET api/<PortfolioTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PortfolioTypeController>
        [HttpPost]
        public async Task<int> AddNewPortfolioType([FromBody] PortfolioType _PortfolioType)
        {

            return await _PortfolioTypeBL.AddNewPortfolioType(_PortfolioType);

        }

        // PUT api/<PortfolioTypeController>/5
        [HttpPut]
        public async Task<PortfolioType> updatePortfolioType([FromBody] PortfolioType _PortfolioType)
        {
            return await _PortfolioTypeBL.updatePortfolioType(_PortfolioType);
        }

        // DELETE api/<PortfolioTypeController>/5
        [HttpDelete("{id}")]
        public async Task DeletePortfolioType(int id)
        {
            await _PortfolioTypeBL.DeletePortfolioType(id);
        }
    }
}
