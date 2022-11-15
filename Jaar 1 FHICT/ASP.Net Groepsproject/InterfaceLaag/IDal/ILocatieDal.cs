using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.DTO;
using InterfaceLaag.Interface;

namespace InterfaceLaag.IDal
{
    public interface ILocatieDal
    {
        public bool LocatieAanmaken(LocatieDTO locatieDTO);
        public List<LocatieDTO> SelecteerLocatiesOpArtikel(int artikelId);
        public List<LocatieDTO> SelecteerLocaties();
        public List<LocatieDTO> SelectLaagsteAantalInLocatie(List<int> artikelID);
        public bool ArtikelIndelenOpLocatie(LocatieDTO locatieDTO);
        public LocatieDTO SelecteerLocatieOpId(int id);
        public LocatieDTO LegeLocatieOphalen();
    }
}
