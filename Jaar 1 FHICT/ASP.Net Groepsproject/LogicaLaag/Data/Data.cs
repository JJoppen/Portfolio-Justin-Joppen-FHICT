using InterfaceLaag.DTO;
using InterfaceLaag.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Data
{
    public class Data
    {
        public int ArtikelId { get; private set; }
        public int ArtikelGroepId { get; private set; }
        public DateTime BestelDatum { get; private set; }
        public int Aantal { get; private set; }
        public string Naam { get; private set; }

        private IData _IDatacontext;

        public Data(IData data)
        {
            _IDatacontext = data;
        }

        public Data()
        {

        }

        public Data(int artikelid, int artikelgroepid, DateTime besteldatum)
        {
            ArtikelId = artikelid;
            ArtikelGroepId = artikelgroepid;
            BestelDatum = besteldatum;
        }

        public Data(int aantal, string naam)
        {
            Aantal = aantal;
            Naam = naam;
        }

        public List<Data> DataDezeMaand()
        {
            List<Data> datas = new List<Data>();
            foreach (DataDTO item in _IDatacontext.DataDezeMaand())
            {
                Data data = new Data(item.Aantal, item.Naam);
                datas.Add(data);
            }
            return datas;
        }

        public List<Data> AantalPerProductDezeMaand()
        {
            List<Data> datas = new List<Data>();
            foreach (DataDTO item in _IDatacontext.AantalPerProductDezeMaand())
            {
                Data data = new Data(item.Aantal, item.Naam);
                datas.Add(data);
            }
            return datas;
        }
    }
}
