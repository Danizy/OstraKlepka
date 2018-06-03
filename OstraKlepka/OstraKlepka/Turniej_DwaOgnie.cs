using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OstraKlepka
{   [Serializable]
//KONSTRUKTOR BEZPARAMETROWY NA PRZYSZLOSC
    public class Turniej_DwaOgnie : Turniej
    {
       private List<Dwa_Ognie> listaDwaOgnie = new List<Dwa_Ognie>();
       public Turniej_DwaOgnie(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow):base(_listaDruzyn,  _listaSedziow)
        {

        }

        public List<Dwa_Ognie> GetlistaDwaOgnie()
        {
            return listaDwaOgnie;
        }

        public override void GenerujMeczeGrupowe()
        {
            for (int i = 0; i < listaDruzyn.Count - 1; i++)
            {
                for (int j = i + 1; j < listaDruzyn.Count; j++)
                {
                    listaDwaOgnie.Add(new Dwa_Ognie(listaDruzyn[i], listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "grupowy"));
                }
            }
        }

        override public void GenerujMeczePolFinal()
        {
            for (int i = 0; i < zwyciezcyGrup.Count - 1; i++)
            {
                for (int j = i + 1; j < zwyciezcyGrup.Count; j++)
                {
                    listaDwaOgnie.Add(new Dwa_Ognie(zwyciezcyGrup[i], zwyciezcyGrup[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));
                }
            }
        }
        override public void GenerujMeczeFinal()
        {
            listaDwaOgnie.Add(new Dwa_Ognie(zwyciezcyPolFinal[0], zwyciezcyPolFinal[1], listaSedziow[random.Next(listaSedziow.Count)], "finałowy"));
        }

        public List<Druzyna> GenerujTabliceWynikow(List<Dwa_Ognie> _listaDwaOgnie)  // ZWRACA LISTĘ POSORTOWANĄ ODWROTNIE!!!        
                                                                                    // OD NAJMNIEJSZEJ ILOŚCI PKT DO NAJWIĘKSZEJ!!!
        {
            List<Druzyna> _listaDruzyn = new List<Druzyna>();   // Zwracana lista
            Druzyna[] _druzyna = new Druzyna[2];    // Pomocnicza tablica do wyciągania drużyn z meczów

            for (int i = 0; i < _listaDwaOgnie.Count; i++)
            {
                _druzyna = _listaDwaOgnie[i].GetDruzyny();
                _listaDruzyn.Add(_druzyna[0]);
                _listaDruzyn.Add(_druzyna[1]);
            }

            _listaDruzyn = _listaDruzyn.Distinct().ToList();

            for (int i = 0; i < _listaDwaOgnie.Count; i++)
            {
                _druzyna = _listaDwaOgnie[i].GetDruzyny();

                if (_listaDwaOgnie[i].wynik1 > _listaDwaOgnie[i].wynik2)
                {
                    for(int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[0].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if(_listaDwaOgnie[i].wynik1 < _listaDwaOgnie[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[1].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if(_listaDwaOgnie[i].wynik1 == _listaDwaOgnie[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[0].nazwa)
                        {
                            _listaDruzyn[j].punkty += 1;
                        }
                        else if(_listaDruzyn[j].nazwa == _druzyna[1].nazwa)
                        {
                            _listaDruzyn[j].punkty += 1;
                        }
                    }
                }
            }
            _listaDruzyn = _listaDruzyn.OrderBy(x => x.punkty).ToList();

            return _listaDruzyn;
        }

        public void ZapiszDoPliku<Turniej_DwaOgnie>(string sciezka, Turniej_DwaOgnie ObiektDoZapisania)
        {
            string nazwaTurnieju;
            nazwaTurnieju = Console.ReadLine();

            using (Stream stream = File.Open(sciezka + nazwaTurnieju + ".ogn", FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, ObiektDoZapisania);
            }
        }
        public Turniej_DwaOgnie OdczytajZPliku<Turniej_DwaOgnie>(string sciezka)

        {

            using (Stream stream = File.Open(sciezka, FileMode.Open))
            {

                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                return (Turniej_DwaOgnie)binaryFormatter.Deserialize(stream);

            }

        }
    }
}
