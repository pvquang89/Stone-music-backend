using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class History
    {
        public string HistoryId { get; set; }
        public string UserId { get; set; }
        public string TrackId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}