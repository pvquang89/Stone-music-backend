using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class User
    {
        public string UserId{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Password{ get; set; }
        public string? Email{ get; set; }
        public string? Avatar{ get; set; }
        public string? Bio{ get; set; }
        public DateTime CreateAt{ get; set; }
        public string Account{ get; set; }

    }
}