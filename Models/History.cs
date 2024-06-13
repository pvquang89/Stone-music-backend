using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Models
{
    public class History
    {
        public string sHistoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //FK
        public string sUserId { get; set; }
        public string sTrackId { get; set; }

    }
}