using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class User
    {
        public string sUserId { get; set; }
        public string sFirstName { get; set; }
        public string sLastName { get; set; }
        public string sPassword { get; set; }
        public string? sEmail { get; set; }
        public string? sAvatar { get; set; }
        public string? sBio { get; set; }
        public DateTime CreatedAt { get; set; }
        public string sAccount { get; set; }

    }
}