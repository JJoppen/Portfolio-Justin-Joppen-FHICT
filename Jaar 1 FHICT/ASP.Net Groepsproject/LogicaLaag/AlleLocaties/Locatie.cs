using InterfaceLaag;
using LogicaLaag.AlleLocaties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.AlleLocaties
{
    public class Locatie
    {
        public int LocatieId { get; set; }
        public int MagazijnId { get; set; }
        public int RijNummer { get; set; }
        public int NiveauId { get; set; }
        public int PlekId { get; set; }
        public int ArtikelId { get; set; }
        public bool IsBezet { get; set; }
        public int AantalInLocatie { get; set; }

        public Locatie()
        {

        }

        public Locatie(int artikelId)
        {
            ArtikelId = artikelId;
        }

        public Locatie(int locatieId, int artikelId)
        {
            LocatieId = locatieId;
            ArtikelId = artikelId;
        }

        public Locatie(int locatieId, int magazijnId, int rijNummer, int niveauId, int plekId, int artikelId, bool isBezet, int aantalInLocatie)
        {
            MagazijnId = magazijnId;
            RijNummer = rijNummer;
            NiveauId = niveauId;
            PlekId = plekId;
            ArtikelId = artikelId;
            IsBezet = isBezet;
            LocatieId = locatieId;
            AantalInLocatie = aantalInLocatie;
        }

        public Locatie(LocatieDTO locatieDTO)
        {
            LocatieId = locatieDTO.LocatieId;
            MagazijnId = locatieDTO.MagazijnId;
            RijNummer = locatieDTO.RijNummer;
            NiveauId = locatieDTO.NiveauId;
            PlekId = locatieDTO.PlekId;
            ArtikelId = locatieDTO.ArtikelId;
            IsBezet = locatieDTO.IsBezet;
            AantalInLocatie = locatieDTO.AantalInLocatie;
        }
    }
}

