using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class TrackGenre
    {
        public string sTrackGenreId { get; set; }
        public string sTrackGenreName { get; set; }

        //collection properties
        public ICollection<Track> Tracks { get; set; }
 
    }
}