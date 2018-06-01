using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{[Serializable]
    public class Siatkowka : Mecz
    {
        private Sedzia_Pomocniczy[] sedziaPom = new Sedzia_Pomocniczy[2];

        public Siatkowka(Druzyna druzyna1, Druzyna druzyna2, Sedzia _sedzia, Sedzia_Pomocniczy sedziaPom1, Sedzia_Pomocniczy sedziaPom2, string _rodzajMeczu) : base(druzyna1, druzyna2, _sedzia, _rodzajMeczu)
        {
            sedziaPom[0] = sedziaPom1;
            sedziaPom[1] = sedziaPom2;
        }

        public Sedzia_Pomocniczy[] getSedziowiePom()
        {
            return sedziaPom;
        }

        public void setSedziowiePom(Sedzia_Pomocniczy sedziaPom1, Sedzia_Pomocniczy sedziaPom2)
        {
            sedziaPom[0] = sedziaPom1;
            sedziaPom[1] = sedziaPom2;
        }
    }
}
