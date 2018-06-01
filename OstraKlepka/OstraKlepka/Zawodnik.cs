using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{[Serializable]
    public class Zawodnik : Osoba
    {
        public string numer { get; set; }

        public Zawodnik(string _imie, string _nazwisko, string _numer)
            : base(_imie, _nazwisko)
        {
            numer = _numer;
        }

        public Zawodnik(Zawodnik _zawodnik)
            : base(_zawodnik.imie, _zawodnik.nazwisko)
        {
            numer = _zawodnik.numer;
        }

        public void SetNumer(string _numer) { numer = _numer; }

        public string GetNumer() { return numer; }
    }
}
