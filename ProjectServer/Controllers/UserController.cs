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
    public class UserController : ControllerBase
    {
        IUserBL _UserBL;
        IMapper _Imapper;
        public UserController(IUserBL UserBL, IMapper imapper)
        {
            _UserBL = UserBL;
            _Imapper = imapper;
        }

        //GET: api/<User2Controller>
        [HttpGet]

        public async Task<List<UserDTO>> GetallUser()
        {
            List<User> res = await _UserBL.GetallUser();
            return _Imapper.Map<List<User>, List<UserDTO>>(res);
        }

        // GET api/<User2Controller>/5
        [HttpGet("{username}/{password}")]
        public async Task<UserDTO> GetUser(string username, string password)
        {
            User res = await _UserBL.GetUser(username, password);
            return _Imapper.Map<User, UserDTO>(res);
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> GetUserById(int id)
        {
            User res = await _UserBL.GetUserById(id);
            return _Imapper.Map<User, UserDTO>(res);
        }

        // POST api/<User2Controller>
        [HttpPost]

        public async Task<int> post(string username)
        {
            return await _UserBL.post(username);
        }

        // PUT api/<User2Controller>/5
        [HttpPut]
        public async Task<Person> updatePerson([FromBody] Person userToChange)
        {
            return await _UserBL.updatePerson(userToChange);
        }

        // DELETE api/<User2Controller>/5
        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            await _UserBL.DeleteUser(id);
        }
    }
}
