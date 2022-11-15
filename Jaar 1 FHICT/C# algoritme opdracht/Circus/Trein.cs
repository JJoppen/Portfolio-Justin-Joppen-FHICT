using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus
{
    public class Trein
    {
        public List<Wagon> wagons{ get; set; }
        public List<Dier> NogNietToegevoegd { get; set; }

        public Trein(List<Dier> nogNietToegevoegd)
        {
            NogNietToegevoegd = nogNietToegevoegd;
        }

        public void VoegToeAanWagons()
        {
            wagons = new List<Wagon>();
            Wagon wagon = new Wagon();
            foreach(Dier dier in NogNietToegevoegd)
            {
                bool IsGeplaatst = false;
                foreach(Wagon wagonCheck in wagons)
                {
                    if(wagonCheck.VoegToeAlsDierErbijKan(dier))
                    {
                        IsGeplaatst = true;
                        break;
                    }
                }
                if(!IsGeplaatst)
                {
                    Wagon wagonToevoegen = new Wagon(dier);
                    wagons.Add(wagonToevoegen);

                }
            }
        }
        public void SchrijfWagonsUit()
        {
            int i = 0;
            foreach(Wagon wagon in wagons)
            {
                Console.WriteLine("De volgende dieren zitten in wagon " + i);
                wagon.SchrijfDierenUit();
                i++;
            }
        }
    }
}
