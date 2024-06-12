using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
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

        //collection properties
        public virtual ICollection<Album>? Albums { get; set; }
        public virtual ICollection<Track>? Tracks { get; set; }
        public virtual ICollection<Playlist>? PlayLists { get; set; }
        public virtual ICollection<History>? Histories { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
        //người theo dõi
        public virtual ICollection<Follow>? Followers { get; set; }
        //người được theo dõi
        public virtual ICollection<Follow>? TrackedPersons { get; set; }
    }
}