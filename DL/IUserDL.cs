using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        //Task<User> GetUser(string username, string password);
        Task<User> GetUser(string username, string password);
       Task<List<User>> GetallUser();
        Task<int> post(User newuser);
        Task DeleteUser(int id);
        Task<User> GetUserbyId(int id);
    }
}