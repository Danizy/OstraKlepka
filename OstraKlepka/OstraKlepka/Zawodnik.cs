using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public class Zawodnik : Osoba
    {
        private string numer;

        public Zawodnik(string _imie, string _nazwisko, string _numer)
            : base(_imie, _nazwisko)
        {
            numer = _numer;
        }

        public void SetNumer(string _numer) { numer = _numer; }

        public string GetNumer() { return numer; }
    }
}
