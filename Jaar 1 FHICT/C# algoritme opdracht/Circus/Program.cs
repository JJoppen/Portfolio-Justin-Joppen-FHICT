using System;
using System.Collections.Generic;

namespace Circus
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dier> dieren = new List<Dier>();
         Dier TestDierGrootVlees1 = new Dier(true, "Leeuw", Grootte.groot);

         Dier TestDierMiddelGrootVlees1 = new Dier(true, "Wolf", Grootte.middelgroot);
         Dier TestDierMiddelGrootVlees2 = new Dier(true, "Hyena", Grootte.middelgroot);
         Dier TestDierMiddelGrootVlees3 = new Dier(true, "Poema", Grootte.middelgroot);


         Dier TestDierKleinVlees1 = new Dier(true, "havik", Grootte.klein);
         Dier TestDierKleinVlees2 = new Dier(true, "Slang", Grootte.klein);
         Dier TestDierKleinVlees3 = new Dier(true, "Kikker", Grootte.klein);


         Dier TestDierKleinHerbivoor1 = new Dier(false, "Konijn", Grootte.klein);
         Dier TestDierKleinHerbivoor2 = new Dier(false, "Muis", Grootte.klein);
         Dier TestDierKleinHerbivoor3 = new Dier(false, "Rat", Grootte.klein);

         Dier TestDierMiddelGrootHerbivoor1 = new Dier(false, "paard", Grootte.middelgroot);
         Dier TestDierMiddelGrootHerbivoor2 = new Dier(false, "aap", Grootte.middelgroot);
         Dier TestDierMiddelGrootHerbivoor3 = new Dier(false, "Koe", Grootte.middelgroot);

         Dier TestDierGrootHerbivoor1 = new Dier(false, "Olifant", Grootte.groot);
         Dier TestDierGrootHerbivoor2 = new Dier(false, "Neushoorn", Grootte.groot);
         Dier TestDierGrootHerbivoor3 = new Dier(false, "Nijlpaard", Grootte.groot);
            dieren.Add(TestDierGrootVlees1);

            dieren.Add(TestDierMiddelGrootVlees1);
            dieren.Add(TestDierMiddelGrootVlees2);
            dieren.Add(TestDierMiddelGrootVlees3);

            dieren.Add(TestDierKleinVlees1);
            dieren.Add(TestDierKleinVlees2);
            dieren.Add(TestDierKleinVlees3);

            dieren.Add(TestDierKleinHerbivoor1);
            dieren.Add(TestDierKleinHerbivoor2);
            dieren.Add(TestDierKleinHerbivoor3);

            dieren.Add(TestDierMiddelGrootHerbivoor1);
            dieren.Add(TestDierMiddelGrootHerbivoor2);
            dieren.Add(TestDierMiddelGrootHerbivoor3);

            dieren.Add(TestDierGrootHerbivoor1);
            dieren.Add(TestDierGrootHerbivoor2);
            dieren.Add(TestDierGrootHerbivoor3);
            Trein trein = new Trein(dieren);
            trein.VoegToeAanWagons();
            trein.SchrijfWagonsUit();
        }
    }
}


