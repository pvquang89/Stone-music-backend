using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using stone_music_backend.Models;

namespace stone_music_backend.Data
{
    public class Album
    {
        public string sAlbumId { get; set; }
        public string sAlbumName { get; set; }
        public string? sDescription { get; set; }
        public DateTime CreatedAt { get; set; }

        //FK
        public string sUserId { get; set; }
        public string sAlbumGenreId { get; set; }

        //references properties
        public virtual AlbumGenre AlbumGenre { get; set; }
        public virtual User User { get; set; }

        //collection properties
        public virtual ICollection<Track> Tracks { get; set; }
    }
}