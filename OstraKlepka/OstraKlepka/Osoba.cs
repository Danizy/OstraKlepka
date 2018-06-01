using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    [Serializable]
    public abstract class Osoba
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }

        protected Osoba(string _imie, string _nazwisko)
        {
            imie = _imie;
            nazwisko = _nazwisko;
        }

        public void SetImie(string _imie) { imie = _imie; }

        public void SetNazwisko(string _nazwisko) { nazwisko = _nazwisko; }

        public string GetImie() { return imie; }

        public string GetNazwisko() { return nazwisko; }

    }
}
