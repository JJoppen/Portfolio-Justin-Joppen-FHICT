using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Layer
{
    public struct ReactieDTO
    {
       public UserDTO userDTO { get; set; }
       public int NummerID { get; set; }
       public int ReactieID { get; set; }
       public string Comment { get; set; }
        public DateTime PlaatsTijd { get; set; }
    }
}
