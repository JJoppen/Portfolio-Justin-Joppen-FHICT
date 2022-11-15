using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.DTO
{
    public class DataDTO
    {
        public int ArtikelId { get; set; }
        public int ArtikelGroepId { get; set; }
        public DateTime BestelDatum { get; set; }
        public int Aantal { get; set; }
        public string Naam { get; set; }
    }
}
