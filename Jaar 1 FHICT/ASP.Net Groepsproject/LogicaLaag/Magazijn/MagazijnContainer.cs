using DAL;
using InterfaceLaag;
using InterfaceLaag.IDal;
using LogicaLaag.AlleLocaties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag
{
    public class MagazijnContainer
    {
        public List<Magazijn> Magazijnen { get; set; }
        private IMagazijnDAL IMagazijnDAL;
        ArtikelContainer artikelContainer = new ArtikelContainer(new ArtikelMSSQL());
        LocatieContainer locatieContainer = new LocatieContainer(new LocatieMSSQL());
        private IArtikelDal IartikelDal;
        private ILocatieDal ILocatieDal;

        public MagazijnContainer(IMagazijnDAL iMagazijnDAl)
        {
            IMagazijnDAL = iMagazijnDAl;
        }

        public bool Aanmaken(Magazijn magazijn)
        {
            Magazijnen = GetAll();
            foreach (Magazijn bestaandMagazijn in Magazijnen)
            {
                if(magazijn == bestaandMagazijn)
                {
                    return false;
                }
                else
                {
                    MagazijnDTO magazijnDTO = new MagazijnDTO
                    {
                        Id = magazijn.Id,
                        Naam = magazijn.Naam,
                        Straatnaam = magazijn.Straatnaam,
                        Huisnummer = magazijn.Huisnummer,
                        Postcode = magazijn.Postcode
                    };
                    Magazijnen.Add(magazijn);
                    bool aanmaken = IMagazijnDAL.Aanmaken(magazijnDTO);
                    if(aanmaken == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public Magazijn Uitlezen(int id)
        {
            MagazijnDTO magazijnDTO = IMagazijnDAL.Ophalen(id);
            if (magazijnDTO.Id == id)
            {
                Magazijn magazijn = new Magazijn(magazijnDTO);
                return magazijn;
            }
            else
            {
                return null;
            }
        }

        public bool Verwijderen(int id)
        {
            MagazijnDTO check = IMagazijnDAL.Ophalen(id);
            if (check.Id == id)
            {
                IMagazijnDAL.Verwijderen(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Magazijn> GetAll()
        {
            List<MagazijnDTO> magazijnDTOs = IMagazijnDAL.SelecteerList();
            foreach (MagazijnDTO magazijnDTO in magazijnDTOs)
            {
                Magazijn magazijn = new Magazijn(magazijnDTO);
                Magazijnen.Add(magazijn);
            }
            return Magazijnen;
        }

        public bool Bewerken(Magazijn magazijn)
        {
            return true;
        }

        public double VulPercentage()
        {
            
            double huidigevoorraad = 0;
            List<Artikel> Artikels = artikelContainer.SelecteerArtikels();
            List<Locatie> locaties = locatieContainer.LocatiesOphalen();
            foreach (Artikel artikel in Artikels)
            {
                huidigevoorraad = artikel.Aantal + huidigevoorraad;
            }
            double maximalevoorraad = locaties.Count * 50;
            double som = huidigevoorraad / maximalevoorraad;
            double percentage = som * 100;
            return percentage;
        }


    }
}
