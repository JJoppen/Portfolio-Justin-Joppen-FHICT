using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.KlantBestelling
{
    public class KlantBestelling
    {
        public KlantBestelling(int artikelaantal, int bestellingID, DateTime dateTime)
        {
            Artikelaantal = artikelaantal;
            BestellingID = bestellingID;
            DagTijd = dateTime;
        }

        public KlantBestelling(int artikelaantal, string artikelnaam, int besteldeartikelID)
        {
            Artikelaantal = artikelaantal;
            Artikelnaam = artikelnaam;
            BesteldeArtikelID = besteldeartikelID;
        }

        public int BestellingID { get; private set; }
        public int Artikelaantal { get; private set; }
        public string Artikelnaam { get; private set; }
        public int BesteldeArtikelID { get; private set; }
        public DateTime DagTijd { get; private set; }
    }
}
