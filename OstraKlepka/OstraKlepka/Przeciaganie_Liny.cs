using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    [Serializable]
    public class Przeciaganie_Liny : Mecz
    {
        public Przeciaganie_Liny(Druzyna druzyna1, Druzyna druzyna2, Sedzia _sedzia, string _rodzajMeczu) : base(druzyna1, druzyna2, _sedzia, _rodzajMeczu)
        {

        }
    }
}
