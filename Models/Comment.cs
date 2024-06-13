using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class Comment
    {
    public string sCommentId{ get; set; }
         public string sContent{ get; set; }
         public DateTime CreatedAt{ get; set; }
         public DateTime? UpdatedAt{ get; set; }

        //FK
         public string sUserId{ get; set; }
         public string sTrackId{ get; set; }

    }
}