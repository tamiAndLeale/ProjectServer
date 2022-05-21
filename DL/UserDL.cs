using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public  class UserDL:IUserDL
    {
        CTContext ctContext;
        //ctor
        public UserDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }
        //get{username},{password}
        public async Task<User> GetUser(string username, string password)
        {
            var a = ctContext.Users.Include(a => a.Person).Where(sor => sor.Person.Id == sor.PersonId).SingleOrDefaultAsync(e => e.UserName == username && e.Password == password);
            return await a;
        }
        //get {id}
        public async Task<User> GetUserbyId(int id)
        {
            var a = ctContext.Users.Include(a => a.Person).Where(sor => sor.Person.Id == sor.PersonId).SingleOrDefaultAsync(e => e.Id == id);
            return await a;
        }
        //getAll
        public async Task<List<User>> GetallUser()
        {

            return await ctContext.Users.Include(a=>a.Person).Where(sor=>sor.Person.Id== sor.PersonId).ToListAsync();
        }

        //post
        public async Task<int> post(User newuser)
        {

            await ctContext.Users.AddAsync(newuser);

            return await ctContext.SaveChangesAsync();

        }
        //delete
        public async Task DeleteUser(int id)
        {
            var UserToDelete = await ctContext.Users.FindAsync(id);
            if (UserToDelete != null)
            {
                ctContext.Users.Remove(UserToDelete);
                await ctContext.SaveChangesAsync();
            }
        }

  
    }
}
