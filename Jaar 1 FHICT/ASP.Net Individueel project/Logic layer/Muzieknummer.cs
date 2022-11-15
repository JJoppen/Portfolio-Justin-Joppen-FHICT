using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inter.Layer;

namespace Logic_layer
{
    public class Muzieknummer
    {
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Type { get; set; }
        public string Tab { get; set; }
        public int userID { get; set; }
        public int MuziekNummerID { get; set; }
        public string YoutubeLink { get; set; }
        public Rating rating { get; set; }

        public Muzieknummer(string naam, string beschrijving, string type)
        {
            Naam = naam;
            Beschrijving = beschrijving;
            Type = type;
        }

        public Muzieknummer(string naam, string beschrijving, string type, string tab, int userID, int muziekNummerID, string youtubeLink) : this(naam, beschrijving, type, tab, userID, muziekNummerID)
        {
            YoutubeLink = youtubeLink;
        }

        public Muzieknummer(string naam, string beschrijving, string type, string tab, int userID, string youtubeLink) : this(naam, beschrijving, type, tab, userID)
        {
            YoutubeLink = youtubeLink;
        }

        public Muzieknummer(string naam, string beschrijving, string type, string tab, int nummerID)
        {
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Type = type;
            this.Tab = tab;
            this.MuziekNummerID = nummerID;
        }
        public Muzieknummer(string naam, string beschrijving, string type, string tab) : this(naam, beschrijving, type)
        {
            Tab = tab;
        }

        public Muzieknummer(string naam, string beschrijving, string type, string tab, int userID, int muziekNummerID) : this(naam, beschrijving, type, tab, userID)
        {
            MuziekNummerID = muziekNummerID;
        }

        public Muzieknummer(MuziekNummerDTO muziekNummerDTO)
        {
            Naam = muziekNummerDTO.Naam;
            Beschrijving = muziekNummerDTO.Beschrijving;
            Type = muziekNummerDTO.Type;
            Tab = muziekNummerDTO.Tab;
            MuziekNummerID = muziekNummerDTO.NummerID;
            userID = muziekNummerDTO.UserID;
            YoutubeLink = muziekNummerDTO.YoutubeLink;
            rating = new Rating(muziekNummerDTO.rating);
        }
    }
}
