using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class Playlist
    {
        
        public string sPlaylistId { get; set; }
        public string sPlaylistName { get; set; }
        public string? sDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool bIsPrivate { get; set; }

        //FK
        public string sUserId { get; set; }
        public string sPlaylistGenreId { get; set; }

    }
}