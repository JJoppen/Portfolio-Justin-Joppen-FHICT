using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabASP.Models
{
    public class UserRatingViewModel
    {
        public int targetID { get; set; }
        public int ExecuterID { get; set; }
        public int rating { get; set; }
    }
}
