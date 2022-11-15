using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circus
{
    public class Dier
    {
        public bool Vleeseter { get; set; }
        public string naam { get; set; }
        public Grootte grootte { get; set; }

        public Dier(bool vleeseter, string naam, Grootte grootte)
        {
            Vleeseter = vleeseter;
            this.naam = naam;
            this.grootte = grootte;
        }
        public bool MagDierErbij(Dier anderdier)
        {
            if (anderdier.Vleeseter && anderdier.grootte >= grootte || Vleeseter && grootte >= anderdier.grootte)
            {
                return false;
            }
            return true;
        }
    }
}
