using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class TrackGenre
    {
        [Required]
        public string TrackGenreId { get; set; }
        [MaxLength(50)]
        public string TrackGenreName { get; set; }

    }
}