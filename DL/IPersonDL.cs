using DTO;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPersonDL
    {

        Task<int> post(Person newPerson);

        Task DeletePerson(int personId);
        Task<Person> updatePerson(Person userToChange);
    }
}