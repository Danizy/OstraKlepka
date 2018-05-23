using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    class Sedzia : Osoba
    {
        private string id;


        public Sedzia(string _imie, string _nazwisko, string _id)
            :base(_imie, _nazwisko)
        {
            id = _id;
        }
    }
}
