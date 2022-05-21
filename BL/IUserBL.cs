using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<User> GetUser(string username, string password);
        Task<List<User>> GetallUser();

        Task<int> post( string username);
        Task<User> GetUserById(int id);
     
        Task DeleteUser(int id);
        Task<Person> updatePerson(Person userToChange);
    }
}