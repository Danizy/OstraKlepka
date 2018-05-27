using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public class Sedzia_Pomocniczy : Sedzia
    {
        public Sedzia_Pomocniczy(string _imie, string _nazwisko, string _id)
            : base(_imie, _nazwisko, _id)
        {

        }

        public Sedzia_Pomocniczy(Sedzia_Pomocniczy _sedzia)
           : base(_sedzia.imie, _sedzia.nazwisko, _sedzia.id)
        {

        }
    }
}
