using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.AlleLocaties
{
    public class Plek
    {
        public int Id { get; set; }
        public int ArtikelId { get; set; }
        public int NiveauId { get; set; }
        public bool IsBezet { get; set; }


        public Plek(int id, int artikelId, int niveauId, bool isBezet)
        {
            Id = id;
            ArtikelId = artikelId;
            NiveauId = niveauId;
            IsBezet = isBezet;
        }

        public Plek(int niveauId, bool isBezet)
        {
            NiveauId = niveauId;
            IsBezet = isBezet;
        }

        public Plek(PlekDTO plekDTO)
        {
            Id = plekDTO.Id;
            ArtikelId = plekDTO.ArtikelId;
            NiveauId = plekDTO.NiveauId;
            IsBezet = plekDTO.IsBezet;
        }
    }
}
