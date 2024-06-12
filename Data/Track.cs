using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
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

        //references properties
        public virtual TrackGenre TrackGenre { get; set; }
        public virtual Album? Album { get; set; }
        public virtual User User { get; set; }

        //collection properties
        //auto generated PlaylistTracks table 
        public virtual ICollection<Playlist_Track> Playlist_Tracks { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }
        public virtual ICollection<History>? Histories { get; set; }



    }
}