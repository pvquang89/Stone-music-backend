using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class Track
    {
        public string sTrackId { get; set; }
        public string sTrackName { get; set; }
        public string? sDescription { get; set; }
        public string sThumbnail { get; set; }
        public string sSource { get; set; }
        public string? sHashtag { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool bIsPrivate { get; set; }

        //FK
        public string sAlbumId { get; set; }
        public string sUserId { get; set; }
        public string sTrackGenreId { get; set; }



    }
}