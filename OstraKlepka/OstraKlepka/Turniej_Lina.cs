using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OstraKlepka
{
    [Serializable]
    public class Turniej_Lina : Turniej
    {
        public List<Przeciaganie_Liny> listaPrzeciaganieLiny = new List<Przeciaganie_Liny>();

        public Turniej_Lina(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow) : base(_listaDruzyn, _listaSedziow)
        {

        }
        
        public Turniej_Lina() : base()
        {

        }

        public List<Przeciaganie_Liny> GetListaMeczowLina() { return listaPrzeciaganieLiny; }

        public override void GenerujMeczeGrupowe()
        {
            for (int i = 0; i < listaDruzyn.Count - 1; i++)
            {
                for (int j = i + 1; j < listaDruzyn.Count; j++)
                {
                    listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(listaDruzyn[i], listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "grupowy"));
                }
            }
        }

        override public void GenerujMeczePolFinal()
        {
            for (int i = 0; i < zwyciezcyGrup.Count - 1; i++)
            {
                for (int j = i + 1; j < zwyciezcyGrup.Count; j++)
                {
                    listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(zwyciezcyGrup[i], zwyciezcyGrup[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));
                }
            }
        }
        override public void GenerujMeczeFinal()
        {
            listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(zwyciezcyPolFinal[0], zwyciezcyPolFinal[1], listaSedziow[random.Next(listaSedziow.Count)], "finałowy"));
        }

        public List<Druzyna> GenerujTabliceWynikow(List<Przeciaganie_Liny> _listaPrzeciaganieLiny)  // ZWRACA LISTĘ POSORTOWANĄ ODWROTNIE!!!        
                                                                                                    // OD NAJMNIEJSZEJ ILOŚCI PKT DO NAJWIĘKSZEJ!!!
        {
            List<Druzyna> _listaDruzyn = new List<Druzyna>();   // Zwracana lista
            Druzyna[] _druzyna = new Druzyna[2];    // Pomocnicza tablica do wyciągania drużyn z meczów

            for (int i = 0; i < _listaPrzeciaganieLiny.Count; i++)
            {
                _druzyna = _listaPrzeciaganieLiny[i].GetDruzyny();
                _listaDruzyn.Add(_druzyna[0]);
                _listaDruzyn.Add(_druzyna[1]);
            }

            _listaDruzyn = _listaDruzyn.Distinct().ToList();

            for (int i = 0; i < _listaDruzyn.Count; i++)
            {
                _listaDruzyn[i] = new Druzyna(_listaDruzyn[i]);
            }

            for (int i = 0; i < _listaPrzeciaganieLiny.Count; i++)
            {
                _druzyna = _listaPrzeciaganieLiny[i].GetDruzyny();

                if (_listaPrzeciaganieLiny[i].wynik1 > _listaPrzeciaganieLiny[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[0].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if (_listaPrzeciaganieLiny[i].wynik1 < _listaPrzeciaganieLiny[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[1].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if (_listaPrzeciaganieLiny[i].wynik1 == _listaPrzeciaganieLiny[i].wynik2)
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

        public void ZapiszDoPliku(string sciezka)
            {

                using (Stream stream = File.Open(sciezka, FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, this);
                }
            }

        public void OdczytajZPliku(string sciezka)

            {

                using (Stream stream = File.Open(sciezka, FileMode.Open))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    Turniej_Lina turniej = (Turniej_Lina)binaryFormatter.Deserialize(stream);

                    if (turniej.listaDruzyn != null)
                {
                    this.listaDruzyn = new List<Druzyna>(turniej.listaDruzyn);
                }
                    
                    if (turniej.listaSedziow != null)
                {
                    this.listaSedziow = new List<Sedzia>(turniej.listaSedziow);
                }
                       
                    if (turniej.listaPrzeciaganieLiny != null)
                {
                    this.listaPrzeciaganieLiny = new List<Przeciaganie_Liny>(turniej.listaPrzeciaganieLiny);
                }
                       /*
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
                      */
                }

            }
    }
}
