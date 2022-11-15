using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public struct PlekDTO
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public int NiveauId { get; set; }
        public bool IsBezet { get; set; }

    }
}
