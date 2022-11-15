using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interface
{
    public interface IMagazijn
    {
        public int StraatNummer { get; }
        public string Postcode { get; }
        public string Naam { get; }
        public string Adres { get; }
    }
}
