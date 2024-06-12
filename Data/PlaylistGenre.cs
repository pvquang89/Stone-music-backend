using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class PlaylistGenre
    {
        public string sPlaylistGenreId { get; set; }
        public string sPlaylistGenreName { get; set; }

         public virtual ICollection<Playlist> Playlists { get; set; }

    }
}