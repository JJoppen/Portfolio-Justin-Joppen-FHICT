using InterfaceLaag.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interface
{
    public interface IData
    {
        public List<DataDTO> DataDezeMaand();
        public List<DataDTO> AantalPerProductDezeMaand();
    }
}
