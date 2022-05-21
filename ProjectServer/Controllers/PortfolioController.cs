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
    public class PortfolioController : ControllerBase
    {
        IPortfolioBL _PortfolioBL;
        IMapper _Imapper;
        public PortfolioController(IPortfolioBL PortfolioBL, IMapper imapper)
        {
            _PortfolioBL = PortfolioBL;
            _Imapper= imapper;
        }


        // GET: api/<PortfolioController>
        [HttpGet]
        public async Task<List<PortfolioDTO>> GetallPortfolios()
        {
            
            List<Portfolio> res = await _PortfolioBL.GetallPortfolios();
            return _Imapper.Map<List<Portfolio>, List<PortfolioDTO>>(res);
        }

        // GET api/<PortfolioController>/5
        [HttpGet("{id}")]
        public async Task<List<PortfolioDTO>> GetPortfoliosOfUser(int id)
        {

            List<Portfolio> res = await _PortfolioBL.GetPortfoliosOfUser(id);
            return _Imapper.Map<List<Portfolio>, List<PortfolioDTO>>(res);
        }

        // POST api/<PortfolioController>
        [HttpPost]
        public async Task<int> AddNewPortfolio([FromBody] Portfolio _Portfolio)
        {

            return await _PortfolioBL.AddNewPortfolio(_Portfolio);

        }

        // PUT api/<PortfolioController>/5
        [HttpPut]
        public async Task<Portfolio> PutAsync([FromBody] Portfolio _Portfolio)
        {
            return await _PortfolioBL.updatePortfolio(_Portfolio);
        }

        // DELETE api/<PortfolioController>/5
        [HttpDelete("{id}")]
        public async Task DeletePortfolio(int id)
        {
            await _PortfolioBL.DeletePortfolio(id);
        }
    }
}
