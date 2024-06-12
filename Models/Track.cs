using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class Track
    {
        public string TrackId{ get; set; }
        public string TrackName{ get; set; }
        public string UserId{ get; set; }
        public string AblumId{ get; set; }
        public string? Description{ get; set; }
        public string Thumbnail{ get; set; }
        public string? Hashtag{ get; set; }
        public DateTime CreateAt{ get; set; }
        public string GenreId{ get; set; }
        public bool IsPrivate{ get; set; }



    }
}