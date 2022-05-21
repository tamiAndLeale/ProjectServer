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
    public class PersonDL : IPersonDL
    {
        CTContext ctContext;
        //ctor
        public PersonDL(CTContext ctContext)
        {
            this.ctContext = ctContext;
        }
        //post
        public async Task<int> post(Person newPerson)
        {
            await ctContext.People.AddAsync(newPerson);
            await ctContext.SaveChangesAsync();
            return  await ctContext.People.MaxAsync(x => x.Id);
           
        }
        //put
        public async Task<Person> updatePerson(Person Person)
        {
            var PersonToUpdate = await ctContext.People.FindAsync(Person.Id);
            ctContext.Entry(PersonToUpdate).CurrentValues.SetValues(Person);
            await ctContext.SaveChangesAsync();
            var newPerson = await ctContext.People.FindAsync(Person.Id);
            return newPerson;

        }
        //delete

        public async Task DeletePerson(int id)
        {
            var PersonToDelete = await ctContext.Portfolio.FindAsync(id);
            if (PersonToDelete != null)
            {
                ctContext.Portfolio.Remove(PersonToDelete);
                await ctContext.SaveChangesAsync();
            }
        }



    }
}
