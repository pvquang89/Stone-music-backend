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
        [Required]
        public string AlbumId{ get; set; }
        [MaxLength(100)]
        [Required]
        public string AlbumName{ get; set; }
        [MaxLength(50)]
        public string Description{ get;set;}
        [Required]
        public DateTime CreateAt { get; set; }
        //FK...
        public string UserId{ get; set; }

    }
}