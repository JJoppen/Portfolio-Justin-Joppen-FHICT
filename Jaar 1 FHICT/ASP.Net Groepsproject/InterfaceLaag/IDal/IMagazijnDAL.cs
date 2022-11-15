using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLaag.Interface;

namespace InterfaceLaag.IDal
{
    public interface IMagazijnDAL : IDalMethods<MagazijnDTO>
    {
        public new bool Aanmaken(MagazijnDTO magazijnDTO);

        public new MagazijnDTO Ophalen(int id);

        public new bool Bewerken(MagazijnDTO magazijnDTO);

        public new bool Verwijderen(int id);

        public new List<MagazijnDTO> SelecteerList();
    }
}
