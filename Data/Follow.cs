using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stone_music_backend.Data
{
    public class Follow
    {
        public string sUserId{ get; set; }
        public string sTrackedPersonId{ get; set; }

        //references properties
        public virtual User Follower { get; set; }
        public virtual User TrackedPerson { get; set; }


    }
}