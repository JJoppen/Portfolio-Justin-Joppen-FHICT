using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarTabASP.Models
{
    public class MuziekNummerViewModel
    {
        
        public string Naam { get; set; }
        public string Tab { get; set; }
        public string Type { get; set; }
        public string Beschrijving { get; set; }
        public int NummerID { get; set; }
        public int userid { get; set; }
        public string youtubelink { get; set; }
        public NummerRatingViewModel rating { get; set; }
        public Uri youtubeUrl
        {
            get
            {
                if(Uri.IsWellFormedUriString(youtubelink,UriKind.Absolute))
                {
                    Uri uri = new Uri(this.youtubelink);
                    return uri;
                }
                else
                {

                    return null;
                }
            }
        }
    }
}
