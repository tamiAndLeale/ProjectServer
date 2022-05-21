
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Portfolios = new HashSet<Portfolio>();
        }

        public int Id { get; set; }
        [EmailAddress]
        public string UserName { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        public int PersonId { get; set; }
       // [JsonIgnore]
        public bool IsManager { get; set; }
        //[JsonIgnore]
        public virtual Person Person { get; set; }
       // [JsonIgnore]
       public virtual ICollection<Portfolio> Portfolios { get; set; }

    }
}
