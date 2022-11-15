using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabASP.Models
{
    public class ReactieViewModel
    {
        public UserViewModel UserViewmodel { get; set; }
        public string Comment { get; set; }
        public int ReactieID { get; set; }
        public int NummerID { get; set; }
        public DateTime PlaatsTijd { get; set; }

    }
}
