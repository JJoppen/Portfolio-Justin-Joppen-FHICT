
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus
{
    public class Wagon
    {
        public List<Dier> dieren;
        public int punten = 0;

        public Wagon()
        {
            dieren = new List<Dier>();
        }
        public Wagon(Dier dier)
        {
            dieren = new List<Dier>();
            VoegToeAlsDierErbijKan(dier);
        }
        private bool MagDierErbij(Dier dier)
        {
            foreach(Dier diercheck in dieren)
            {
                if(dier.MagDierErbij(diercheck) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool VoegToeAlsDierErbijKan(Dier dier)
        {
            if(MagDierErbij(dier))
            {
                if(punten + (int)dier.grootte > 10)
                {
                    return false;
                }
                else
                {
                    dieren.Add(dier);
                    punten = punten + (int)Grootte.groot;
                    return true;
                }

            }
            return false;
        }

        public void SchrijfDierenUit()
        {
            foreach(Dier dier in dieren)
            {
                Console.WriteLine(dier.naam);
            }
        }
    }
}
