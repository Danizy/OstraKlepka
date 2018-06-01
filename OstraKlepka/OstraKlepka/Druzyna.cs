using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    [Serializable]
    public class Druzyna
    {
        private List<Zawodnik> listaZawodnikow = new List<Zawodnik>();
        public int punkty { get; set; } 
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

        public Druzyna(Druzyna _druzyna)
        {
            nazwa = _druzyna.nazwa;
            punkty = _druzyna.punkty;
            setyPrzegrane = _druzyna.setyPrzegrane;
            setyWygrane = _druzyna.setyWygrane;
        }

        public void setNazwa(string _nazwa) { nazwa = _nazwa; }

        public string getNazwa() { return nazwa; }

        public void DodajZawodnika(Zawodnik _zawodnik)
        {
            listaZawodnikow.Add(new Zawodnik(_zawodnik));
        }

        public void UsunZawodnika(int id)
        {
            listaZawodnikow.RemoveAt(id);
        }

        public void EdytujZawodnika(int _id, Zawodnik _zawodnik)
        {
            //TODO edytowanie zawodnika, funkcja dostaje id zawodnika i gotowego edytowanego zawodnika
        }

        public List<Zawodnik> GetZawodnicy()
        {
            return listaZawodnikow;
        }
    }
}
