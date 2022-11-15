using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public class GebruikerDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        public string PriorityLevel { get; set; }
    }
}
