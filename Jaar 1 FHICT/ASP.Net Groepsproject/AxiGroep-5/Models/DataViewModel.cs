using LogicaLaag;
using LogicaLaag.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AxiGroep_5.Models
{
    public class DataViewModel
    {
        public IEnumerable<Data> DataIEnum { get; set; }
        public IEnumerable<Data> DataIEnum2 { get; set; }
        public double Percentage { get; set; }
    }
}
