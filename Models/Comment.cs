using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class Comment
    {
         public string CommentId{ get; set; }
         public string UserId{ get; set; }
         public string TrackId{ get; set; }
         public string Content{ get; set; }
         public DateTime CreatedAt{ get; set; }
         public DateTime? UpdateAt{ get; set; }

    }
}