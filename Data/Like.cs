using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class Like
    {
        public string sUserId { get; set; }
        public string sTrackId { get; set; }

        //references properties
        public virtual User User { get; set; }
        public virtual Track Track { get; set; }

    }
}