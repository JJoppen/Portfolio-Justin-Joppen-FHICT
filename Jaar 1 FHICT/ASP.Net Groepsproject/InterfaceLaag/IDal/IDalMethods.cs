using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.IDal
{
    public interface IDalMethods<T>
    {
        public bool Aanmaken(T obj);
        public T Ophalen(int id);
        public bool Bewerken(T obj);
        public bool Verwijderen(int id);
        public List<T> SelecteerList();
    }
}
