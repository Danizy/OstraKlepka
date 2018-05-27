using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public class Druzyna
    {
        private List<Zawodnik> listaZawodnikow;
        private int punkty; 
        public string nazwa { get; set; }
        private int setyPrzegrane;
        private int setyWygrane;

        public Druzyna(string _nazwa)
        {
            nazwa = _nazwa;
            punkty = 0;
            setyPrzegrane = 0;
            setyWygrane = 0;
        }

        public void setNazwa(string _nazwa) { nazwa = _nazwa; }

        public string getNazwa() { return nazwa; }
    }
}
