﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OstraKlepka
{   [Serializable]
    public class Turniej_DwaOgnie : Turniej
    {
        private List<Dwa_Ognie> listaDwaOgnie = new List<Dwa_Ognie>(); //lista list meczy w dwa ognie

        public Turniej_DwaOgnie(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow) : base(_listaDruzyn, _listaSedziow)
        {

        }

        public Turniej_DwaOgnie() : base()
        {

        }

        public List<Dwa_Ognie> GetlistaDwaOgnie()
         {
            return listaDwaOgnie;
         }

        public List<Dwa_Ognie> GetListaMeczowDwaOgnie() { return listaDwaOgnie; }

        public List<Dwa_Ognie> GenerujMeczeDogrywki(List<Druzyna> listaDruzyn)
        {
            List<Dwa_Ognie> mecze = new List<Dwa_Ognie>();
            for (int i = 0; i < listaDruzyn.Count - 1; i++)
            {

                for (int j = i + 1; j < listaDruzyn.Count; j++)
                {
                    mecze.Add(new Dwa_Ognie(listaDruzyn[i], listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "grupowy"));
                }
            }
           return mecze;
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

        override public List<Druzyna>[] GenerujMeczePolFinal(List<Druzyna> _listaDruzyn = null)
        {
            int i = 0;
            if (_listaDruzyn != null)
            {
                listaDruzyn.Clear();
                listaDruzyn = new List<Druzyna>(_listaDruzyn);

                foreach (Druzyna druzyna in listaDruzyn)
                    druzyna.punkty = 0;

                listaDwaOgnie.Clear();
                for (i = 0; i < _listaDruzyn.Count - 1; i++)
                {
                    for (int j = i + 1; j < _listaDruzyn.Count; j++)
                    {
                        listaDwaOgnie.Add(new Dwa_Ognie(_listaDruzyn[i], _listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));
                    }
                }
                return null;
            }



            List<Druzyna> _wszyscy = new List<Druzyna>(GenerujTabliceWynikow(listaDwaOgnie));
            List<Druzyna>[] _tabList = new List<Druzyna>[2];
            List<Druzyna> _zwyciezcy = new List<Druzyna>();
            List<Druzyna> _dogrywka = new List<Druzyna>();
            wynikiGrup = new List<Druzyna>(_wszyscy);
            i = 0;

            while(i < _wszyscy.Count && _wszyscy[i].punkty >= _wszyscy[3].punkty)
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
                listaDwaOgnie.Clear();
                for (i = 0; i < _zwyciezcy.Count - 1; i++)
                {
                    for (int j = i + 1; j < _zwyciezcy.Count; j++)
                    {
                        listaDwaOgnie.Add(new Dwa_Ognie(_zwyciezcy[i], _zwyciezcy[j], listaSedziow[random.Next(listaSedziow.Count)], "półfinałowy"));                       
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

                listaDwaOgnie.Clear();
                for (i = 0; i < _listaDruzyn.Count - 1; i++)
                {
                    for (int j = i + 1; j < _listaDruzyn.Count; j++)
                    {
                        listaDwaOgnie.Add(new Dwa_Ognie(_listaDruzyn[i], _listaDruzyn[j], listaSedziow[random.Next(listaSedziow.Count)], "finałowy"));
                    }
                }

                return null;
            }

            List<Druzyna> _wszyscy = new List<Druzyna>(GenerujTabliceWynikow(listaDwaOgnie));
            List<Druzyna>[] _tabList = new List<Druzyna>[2];
            List<Druzyna> _zwyciezcy = new List<Druzyna>();
            List<Druzyna> _dogrywka = new List<Druzyna>();
            wynikiPolfinal = new List<Druzyna>(_wszyscy);
            i = 0;

            while (i < _wszyscy.Count && _wszyscy[i].punkty >= _wszyscy[1].punkty)
            {
                _zwyciezcy.Add(new Druzyna(_wszyscy[i]));
                i++;
            }
            if (_zwyciezcy.Count > 2)
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
                listaDwaOgnie.Clear();
                listaDwaOgnie.Add(new Dwa_Ognie(_zwyciezcy[0], _zwyciezcy[1], listaSedziow[random.Next(listaSedziow.Count)], "finałowy"));
            }
            listaDruzyn.Clear();
            listaDruzyn = new List<Druzyna>(listaDruzyn);
            _zwyciezcy = new List<Druzyna>(_zwyciezcy);

            foreach (Druzyna druzyna in _zwyciezcy)
                druzyna.punkty = 0;

            _tabList[0] = new List<Druzyna>(_zwyciezcy);
            return _tabList;        
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

            for (int i = 0; i < _listaDruzyn.Count; i++)
            {
                _listaDruzyn[i] = new Druzyna(_listaDruzyn[i]);
            }

            for (int i = 0; i < _listaDwaOgnie.Count; i++)
            {
                _druzyna = _listaDwaOgnie[i].GetDruzyny();

                if (_listaDwaOgnie[i].wynik1 > _listaDwaOgnie[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[0].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if (_listaDwaOgnie[i].wynik1 < _listaDwaOgnie[i].wynik2)
                {
                    for (int j = 0; j < _listaDruzyn.Count; j++)     // Nie wiem jak przeszukać jebaną listę gotową funkcją, pozdrawiam :)
                    {
                        if (_listaDruzyn[j].nazwa == _druzyna[1].nazwa)
                        {
                            _listaDruzyn[j].punkty += 3;
                        }
                    }
                }

                else if (_listaDwaOgnie[i].wynik1 == _listaDwaOgnie[i].wynik2)
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
            string nazwaTurnieju;
            nazwaTurnieju = Console.ReadLine();

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
                Turniej_DwaOgnie turniej = (Turniej_DwaOgnie)binaryFormatter.Deserialize(stream);

                if (turniej.listaDruzyn != null)
                {
                    this.listaDruzyn = new List<Druzyna>(turniej.listaDruzyn);
                }
                  
                if (turniej.listaSedziow != null)
                {
                    this.listaSedziow = new List<Sedzia>(turniej.listaSedziow);
                }
                   
                if (turniej.listaDwaOgnie != null)
                {
                    this.listaDwaOgnie = new List<Dwa_Ognie>(turniej.listaDwaOgnie);
                }
                if (turniej.wynikiGrup != null)
                {
                    this.wynikiGrup = new List<Druzyna>(turniej.wynikiGrup);
                }
                if (turniej.wynikiPolfinal != null)
                {
                    this.wynikiPolfinal = new List<Druzyna>(turniej.wynikiPolfinal);
                }
                if (turniej.wynikiFinal != null)
                {
                    this.wynikiFinal = new List<Druzyna>(turniej.wynikiFinal);
                }                                    

            }
        }
    }
}
