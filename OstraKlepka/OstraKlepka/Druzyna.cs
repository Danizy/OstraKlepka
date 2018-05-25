using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    class Druzyna
    {
        private List<Zawodnik> listaZawodnikow;
        private int punkty;
        private string nazwa;
        private int setyPrzegrane;
        private int setyWygrane;

        public Druzyna(string _nazwa)
        {
            nazwa = _nazwa;
            setyPrzegrane = 0;
            setyWygrane = 0;
        }

        public void setNazwa(string _nazwa) { nazwa = _nazwa; }

        public string getNazwa() { return nazwa; }
    }
}
