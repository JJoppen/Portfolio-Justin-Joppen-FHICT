using DAL;
using InterfaceLaag;
using InterfaceLaag.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Winkelmandje
{
    public class WinkelmandjeContainer
    {
        private IWinkelmandje iwinkelmandje;

        public WinkelmandjeContainer(IWinkelmandje winkelmandje)
        {
            this.iwinkelmandje = winkelmandje;
        }

        public ArtikelDTO OmzettenNaarArtikelDTO(Artikel artikel)
        {
            ArtikelDTO artikeldto = new ArtikelDTO()
            {
                Prijs = artikel.Prijs,
                ArtikelID = artikel.ArtikelID,
                ArtikelNummer = artikel.ArtikelNummer,
                Aantal = artikel.Aantal,
                Beschrijving = artikel.Beschrijving,
                Tht = artikel.THT,
                Naam = artikel.Artikelnaam,
                Kleur = artikel.Kleur,
                Gewicht = artikel.Gewicht,
                Afmeting = artikel.Afmeting,
                IsVoedsel = artikel.IsVoedsel
            };
            return artikeldto;
        }

        public void BestelWinkelmandje(List<Artikel> artikels, int GebruikerID)
        {
            List<ArtikelDTO> artikelDTOs = new List<ArtikelDTO>();
            foreach(Artikel artikel in artikels)
            {
                artikelDTOs.Add(OmzettenNaarArtikelDTO(artikel));
            }
            iwinkelmandje.BestelWinkelmandje(artikelDTOs, GebruikerID);
        }
    }
}
