using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class Person
    {
        public Person()
        {
            Users = new HashSet<User>();
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public int Id { get; set; }
        public string? Identity { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
