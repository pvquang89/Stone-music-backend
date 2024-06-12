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
        
        [Required]
        public string PlaylistId { get; set ;}
        [Required]
        public string PlaylistName { get; set ;}

        public string? Description { get; set ;}
        public DateTime CreateAt { get; set ;}
        [Required]
        public bool IsPrivate { get; set ;}
        //FK
        public string UserId { get; set; }

    }
}