using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public class Sedzia : Osoba
    {
        public string id { get; set; }


        public Sedzia(string _imie, string _nazwisko, string _id)
            :base(_imie, _nazwisko)
        {
            id = _id;
        }

        public Sedzia(Sedzia _sedzia)
            :base(_sedzia.imie, _sedzia.nazwisko)
        {
            id = _sedzia.id;
        }
    }
}
