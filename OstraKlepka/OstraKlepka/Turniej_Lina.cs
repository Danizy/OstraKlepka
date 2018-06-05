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
        public List<Przeciaganie_Liny> listaPrzeciaganieLiny = new List<Przeciaganie_Liny>(); //lista list meczy w przeciaganie liny

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

        public List<Przeciaganie_Liny> GenerujMeczeDogrywki(List<Druzyna> listaDruzyn)
        {
            List<Przeciaganie_Liny> mecze = new List<Przeciaganie_Liny>();
            for (int i = 0; i < listaDruzyn.Count - 1; i++)
            {

                for (int j = i + 1; j < listaDruzyn.Count; j++)
                {
                    mecze.Add(new Przeciaganie_Liny(listaDruzyn[i], listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));
                }
            }
            return mecze;
        }

        override public List<Druzyna>[] GenerujMeczePolFinal(List<Druzyna> _listaDruzyn = null)
        {
            int i = 0;
            if (_listaDruzyn != null)
            {
                listaDruzyn.Clear();
                listaDruzyn = new List<Druzyna>(_listaDruzyn);

                foreach (Druzyna druzyna in listaDruzyn)
                    druzyna.punkty = 0;

                listaPrzeciaganieLiny.Clear();
                for (i = 0; i < _listaDruzyn.Count - 1; i++)
                {
                    for (int j = i + 1; j < _listaDruzyn.Count; j++)
                    {
                        listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(_listaDruzyn[i], _listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));
                    }
                }
                return null;
            }

            List<Druzyna> _wszyscy = new List<Druzyna>(GenerujTabliceWynikow(listaPrzeciaganieLiny));
            List<Druzyna>[] _tabList = new List<Druzyna>[2];
            List<Druzyna> _zwyciezcy = new List<Druzyna>();
            List<Druzyna> _dogrywka = new List<Druzyna>();
            wynikiGrup = new List<Druzyna>(_wszyscy);
            i = 0;

            while (i < _wszyscy.Count && _wszyscy[i].punkty >= _wszyscy[3].punkty)
            {
                _zwyciezcy.Add(new Druzyna(_wszyscy[i]));
                i++;
            }
            if (_zwyciezcy.Count > 4)
            {
                i = _zwyciezcy.Count - 1;
                int pkt = _zwyciezcy[3].punkty;

                while (_zwyciezcy[i].punkty == pkt)
                {
                    _dogrywka.Add(new Druzyna(_zwyciezcy[i]));
                    _zwyciezcy.RemoveAt(i);
                    i--;
                }
                _tabList[0] = new List<Druzyna>(_zwyciezcy);
                _tabList[1] = new List<Druzyna>(_dogrywka);
            }

            else
            {
                listaPrzeciaganieLiny.Clear();
                for (i = 0; i < _zwyciezcy.Count - 1; i++)
                {
                    for (int j = i + 1; j < _zwyciezcy.Count; j++)
                    {
                        listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(_zwyciezcy[i], _zwyciezcy[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));
                    }
                }
            }
            listaDruzyn.Clear();
            listaDruzyn = new List<Druzyna>(_zwyciezcy);

            foreach (Druzyna druzyna in listaDruzyn)
                druzyna.punkty = 0;

            _tabList[0] = new List<Druzyna>(_zwyciezcy);
            return _tabList;
        }

        override public List<Druzyna>[] GenerujMeczeFinal(List<Druzyna> _listaDruzyn = null)
        {
            int i = 0;
            if (_listaDruzyn != null)
            {

                listaDruzyn.Clear();
                listaDruzyn = new List<Druzyna>(_listaDruzyn);

                foreach (Druzyna druzyna in listaDruzyn)
                    druzyna.punkty = 0;

                listaPrzeciaganieLiny.Clear();
                for (i = 0; i < _listaDruzyn.Count - 1; i++)
                {
                    for (int j = i + 1; j < _listaDruzyn.Count; j++)
                    {
                        listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(_listaDruzyn[i], _listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "finałowy"));
                    }
                }
                return null;
            }

            List<Druzyna> _wszyscy = new List<Druzyna>(GenerujTabliceWynikow(listaPrzeciaganieLiny));
            List<Druzyna>[] _tabList = new List<Druzyna>[2];
            List<Druzyna> _zwyciezcy = new List<Druzyna>();
            List<Druzyna> _dogrywka = new List<Druzyna>();
            wynikiGrup = new List<Druzyna>(_wszyscy); // pod else
            i = 0;

            while (i < _wszyscy.Count && _wszyscy[i].punkty >= _wszyscy[1].punkty)
            {
                _zwyciezcy.Add(new Druzyna(_wszyscy[i]));
                i++;
            }
            if (_zwyciezcy.Count > 4)
            {
                i = _zwyciezcy.Count - 1;
                int pkt = _zwyciezcy[1].punkty;

                while (_zwyciezcy[i].punkty == pkt)
                {
                    _dogrywka.Add(new Druzyna(_zwyciezcy[i]));
                    _zwyciezcy.RemoveAt(i);
                    i--;
                }
                _tabList[0] = new List<Druzyna>(_zwyciezcy);
                _tabList[1] = new List<Druzyna>(_dogrywka);
            }

            else
            {
                listaPrzeciaganieLiny.Clear();
                listaPrzeciaganieLiny.Add(new Przeciaganie_Liny(_zwyciezcy[0], _zwyciezcy[1], listaSedziow[random.Next(listaSedziow.Count)], "finałowy"));
            }
            listaDruzyn.Clear();
            listaDruzyn = new List<Druzyna>(_zwyciezcy);

            foreach (Druzyna druzyna in listaDruzyn)
                druzyna.punkty = 0;
            _tabList[0] = new List<Druzyna>(_zwyciezcy);
            return _tabList;
        }

        public List<Druzyna> GenerujTabliceWynikow(List<Przeciaganie_Liny> _listaPrzeciaganieLiny)// OD NAJMNIEJSZEJ ILOŚCI PKT DO NAJWIĘKSZEJ!!!
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
                if(turniej.wynikiGrup!=null)
                {
                    this.wynikiGrup = new List<Druzyna>(turniej.wynikiGrup);
                }
                if(turniej.wynikiPolfinal!=null)
                {
                    this.wynikiPolfinal = new List<Druzyna>(turniej.wynikiPolfinal);
                }
                if(turniej.wynikiFinal!=null)
                {
                    this.wynikiFinal = new List<Druzyna>(turniej.wynikiFinal);
                }

            }
        }
    }
}