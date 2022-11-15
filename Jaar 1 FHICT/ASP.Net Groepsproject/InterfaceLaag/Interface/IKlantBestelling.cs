using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO; 

namespace InterfaceLaag.Interface
{
    public interface IKlantBestelling
    {
        public List<KlantBestellingDTO> getbestelling();
        public List<KlantBestellingDTO> GetBestellingDetails(KlantBestellingDTO klantBestellingDTO);
        public void BestellingAfronden(KlantBestellingDTO klantBestellingDTO);
    }
}
