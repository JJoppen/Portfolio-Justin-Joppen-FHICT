using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inter.Layer
{
    public struct MuziekNummerDTO
    {
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Type { get; set; }
        public string Tab { get; set; }
        public int UserID { get; set; }
        public int NummerID { get; set; }
        public string YoutubeLink { get; set; }
        public RatingDTO rating { get; set; }
    }
}
