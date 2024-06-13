using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class Album
    {
       public string sAlbumId { get; set; }
        public string sAlbumName { get; set; }
        public string? sDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        
        //FK
        public string sUserId { get; set; }
        public string sAlbumGenreId { get; set; }

    }
}