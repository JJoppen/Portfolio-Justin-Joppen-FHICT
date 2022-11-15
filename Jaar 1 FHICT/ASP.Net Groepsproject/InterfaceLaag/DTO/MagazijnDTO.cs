using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag
{
    public struct MagazijnDTO
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Straatnaam { get; set; }
        public int Huisnummer { get; set; }
        public string Postcode { get; set; }
        public List<LocatieDTO> Locaties { get; set; }
    }
}
