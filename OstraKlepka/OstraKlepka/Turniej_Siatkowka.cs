using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



// DOPISAC KONSTRUKTORY BEZPARAMETROWE - RUDINI
namespace OstraKlepka
{   [Serializable]
    public class Turniej_Siatkowka : Turniej
    {
        public List<Siatkowka> listaMeczowSiatkowki = new List<Siatkowka>();
        private List<Sedzia_Pomocniczy> listaSedziowPom = new List<Sedzia_Pomocniczy>();
        private int[] randomTab = new int[2];  // tablica potrzebna do losowania sędziów pomocniczych

        public Turniej_Siatkowka()
        {

        }

        public Turniej_Siatkowka (List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow, List<Sedzia_Pomocniczy> _listaSedziowPom):base(_listaDruzyn, _listaSedziow)
        {
            listaSedziowPom = new List<Sedzia_Pomocniczy>(_listaSedziowPom);
        }

        public void SetSedziowiePom(List<Sedzia_Pomocniczy> _listaSedziowPom)
        {
            listaSedziowPom = new List<Sedzia_Pomocniczy>(_listaSedziowPom);
        }

        public List<Sedzia_Pomocniczy> GetSedziowiePom()
        {
            return listaSedziowPom;
        }

        private void losowaniePomocniczych()
        {
            randomTab[0] = random.Next(listaSedziowPom.Count);
            randomTab[1] = random.Next(listaSedziowPom.Count);

            while (randomTab[0] == randomTab[1])
            {
                randomTab[1] = random.Next(listaSedziowPom.Count);
            }
        }

        public override void GenerujMeczeGrupowe()
        {
            for (int i = 0; i < listaDruzyn.Count - 1 ; i++)
            {
                for(int j = i + 1; j < listaDruzyn.Count; j++)
                {
                    losowaniePomocniczych();
                    listaMeczowSiatkowki.Add(new Siatkowka(listaDruzyn[i], listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)],
                                                           listaSedziowPom[randomTab[0]], listaSedziowPom[randomTab[1]], "grupowy"));
                }
            }          
        }

        override public void GenerujMeczePolFinal()
        {
            for (int i = 0; i < zwyciezcyGrup.Count - 1; i++)
            {
                for (int j = i + 1; j < zwyciezcyGrup.Count; j++)
                {
                    losowaniePomocniczych();
                    listaMeczowSiatkowki.Add(new Siatkowka(zwyciezcyGrup[i], zwyciezcyGrup[j], listaSedziow[random.Next(listaSedziow.Count)],
                                                           listaSedziowPom[randomTab[0]], listaSedziowPom[randomTab[1]], "półfinałowy"));
                }
            }
        }

        override public void GenerujMeczeFinal()
        {
            losowaniePomocniczych();
            listaMeczowSiatkowki.Add(new Siatkowka(zwyciezcyPolFinal[0], zwyciezcyPolFinal[1], listaSedziow[random.Next(listaSedziow.Count)],
                                                   listaSedziowPom[randomTab[0]], listaSedziowPom[randomTab[1]], "finałowy"));
        }

        public List<Druzyna> GenerujTabliceWynikow(List<Siatkowka> _listaMeczowSiatkowki)  // ZWRACA LISTĘ POSORTOWANĄ ODWROTNIE!!!        
                                                                                    // OD NAJMNIEJSZEJ ILOŚCI PKT DO NAJWIĘKSZEJ!!!
        {
            List<Druzyna> _listaDruzyn = new List<Druzyna>();   // Zwracana lista
            Druzyna[] _druzyna = new Druzyna[2];    // Pomocnicza tablica do wyciągania drużyn z meczów

            for (int i = 0; i < _listaMeczowSiatkowki.Count; i++)
            {
                _druzyna = (_listaMeczowSiatkowki[i].GetDruzyny());
                _listaDruzyn.Add(_druzyna[0]);
                _listaDruzyn.Add(_druzyna[1]);
            }

            _listaDruzyn = _listaDruzyn.Distinct().ToList();

            for (int i = 0; i < _listaDruzyn.Count; i++)
            {
                _listaDruzyn[i] = new Druzyna(_listaDruzyn[i]);
            }

            for (int i = 0; i < _listaMeczowSiatkowki.Count; i++)
            {
                _druzyna = _listaMeczowSiatkowki[i].GetDruzyny();

                if (_listaMeczowSiatkowki[i].wynik1 > _listaMeczowSiatkowki[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[0].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if (_listaMeczowSiatkowki[i].wynik1 < _listaMeczowSiatkowki[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[1].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if (_listaMeczowSiatkowki[i].wynik1 == _listaMeczowSiatkowki[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[0].nazwa)
                        {
                            _listaDruzyn[j].punkty += 1;
                        }
                        else if (_listaDruzyn[j].nazwa == _druzyna[1].nazwa)
                        {
                            _listaDruzyn[j].punkty += 1;
                        }
                    }
                }
            }
            _listaDruzyn = _listaDruzyn.OrderBy(x => x.punkty).ToList();
            _listaDruzyn.Reverse();

            return _listaDruzyn;
        }

        public List<Siatkowka> GetListaMeczowSiatkowki()
        {
            return listaMeczowSiatkowki;
        }

        public void ZapiszDoPliku<Turniej_Siatkowka>(string sciezka, Turniej_Siatkowka ObiektDoZapisania)
        {

            using (Stream stream = File.Open(sciezka, FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, ObiektDoZapisania);
            }
        }

        public void OdczytajZPliku(string sciezka)

        {

            using (Stream stream = File.Open(sciezka, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Turniej_Siatkowka turniej = (Turniej_Siatkowka)binaryFormatter.Deserialize(stream);

                if (turniej.listaDruzyn != null)
                {
                    this.listaDruzyn = new List<Druzyna>(turniej.listaDruzyn);
                }

                if (turniej.listaSedziow != null)
                {
                    this.listaSedziow = new List<Sedzia>(turniej.listaSedziow);
                }
                if (turniej.listaSedziowPom != null)

                {
                    this.listaSedziowPom = new List<Sedzia_Pomocniczy>(turniej.listaSedziowPom);
                }
                if (turniej.listaMeczowSiatkowki != null)
                {
                    this.listaMeczowSiatkowki = new List<Siatkowka>(turniej.listaMeczowSiatkowki);
                }
                    
                if (turniej.zwyciezcyFinal != null)
                {
                    this.zwyciezcyFinal = new List<Druzyna>(turniej.zwyciezcyFinal);
                }

                if (turniej.zwyciezcyGrup != null)
                {
                    this.zwyciezcyGrup = new List<Druzyna>(turniej.zwyciezcyGrup);
                }
                   
                if (turniej.zwyciezcyPolFinal != null)
                {
                    this.zwyciezcyPolFinal = new List<Druzyna>(turniej.zwyciezcyPolFinal);
                }
            }
        }  
    }
}

