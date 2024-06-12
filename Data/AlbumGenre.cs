using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class AlbumGenre
    {
        public string sAlbumGenreId { get; set; }
        public string sAlbumGenreName { get; set; }

  
        //collection properties
        public virtual ICollection<Album> Albums { get; set; }

    }
}