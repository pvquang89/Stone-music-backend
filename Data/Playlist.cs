using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class Playlist
    {
        public string sPlaylistId { get; set ;}
        public string sPlaylistName { get; set ;}
        public string? sDescription { get; set ;}
        public DateTime CreatedAt { get; set ;}
        public bool bIsPrivate { get; set ;}

        //FK
        public string sUserId { get; set; }
        public string sPlaylistGenreId { get; set;}

        //references properties
        public virtual User User { get; set; }
        public virtual PlaylistGenre PlaylistGenre { get; set;}
        //collection properties
        //auto generated PlaylistTracks table 
        public virtual ICollection<Playlist_Track> Playlist_Tracks{ get; set; }

    }
}