using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class Playlist_Track
    {
        public string PlayListId { get; set; }

        public string TrackId { get; set; }


        // reference property

        public virtual Playlist PlayList { get; set; }

        public virtual Track Track { get; set; }
    }
}