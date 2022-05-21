using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserDTO
    {
        public int Id { get; set; }  
        public int PersonId { get; set; }
        public string? Identity { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        [EmailAddress]
        public string UserName { get; set; }
        [MinLength(4)]
        public string Password { get; set; }
        public bool IsManager { get; set; }
    }
}
