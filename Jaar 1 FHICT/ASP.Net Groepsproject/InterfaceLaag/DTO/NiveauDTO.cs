using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public struct NiveauDTO
    {
        public int NiveauId { get; set; }
        public int RijId { get; set; }
        public List<PlekDTO> Plekken { get; set; }

    }
}
