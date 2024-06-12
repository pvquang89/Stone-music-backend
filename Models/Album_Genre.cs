using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class Album_Genre
    {
        [Required]
        public string AlbumGenreId { get; set;}
        [Required]
        public string AlbumGenreName { get; set;}
    }
}