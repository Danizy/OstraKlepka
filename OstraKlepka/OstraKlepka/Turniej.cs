using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public abstract class Turniej
    {
        protected List<Druzyna> listaDruzyn;
        protected List<Sedzia> listaSedziow;
        protected List<Mecz> listaMeczow;
        protected List<Druzyna> zwyciezcyGrup;
        protected List<Druzyna> zwyciezcyPolFinal;
        protected List<Druzyna> zwyciezcyFinal;
        protected Random random;
      

        public Turniej(List<Druzyna> _listaDruzyn,List<Sedzia> _listaSedziow,List<Mecz> _listaMeczow, List<Druzyna> _zwyciezcyGrup, 
                       List<Druzyna> _zwyciezcyPolFinal, List<Druzyna> _zwyciezcyFinal)
        {
            listaDruzyn = new List<Druzyna>(_listaDruzyn);
            listaSedziow = new List<Sedzia>(_listaSedziow);
            listaMeczow = new List<Mecz>(_listaMeczow);
            zwyciezcyGrup = new List<Druzyna>(_zwyciezcyGrup);
            zwyciezcyPolFinal = new List<Druzyna>(_zwyciezcyPolFinal);
            zwyciezcyFinal = new List<Druzyna>(_zwyciezcyFinal);
        }
        public void SetDruzyny(List<Druzyna> _listaDruzyn)
        {
            listaDruzyn = new List<Druzyna>(_listaDruzyn);
        }

        public void SetSedziowie(List<Sedzia> _listaSedziow)
        {
            listaSedziow = new List<Sedzia>(_listaSedziow);
        }

        public List<Druzyna> GetDruzyny()
        {
            return listaDruzyn;
        }

        public List<Sedzia> GetSedziowie()
        {
            return listaSedziow;
        }

        public void AddZwyciezceGrup(Druzyna _druzyna)
        {
            zwyciezcyGrup.Add(new Druzyna(_druzyna));
        }

        public void AddZwyciezcePolFinal(Druzyna _druzyna)
        {
            zwyciezcyPolFinal.Add(new Druzyna(_druzyna));
        }

        public void AddZwyciezceFinal(Druzyna _druzyna)
        {
            zwyciezcyFinal.Add(new Druzyna(_druzyna));
        }

        public List<Druzyna> GetZwyciezcyGrup()
        {
            return zwyciezcyGrup;
        }

        public List<Druzyna> GetZwyciezcyPolFinal()
        {
            return zwyciezcyPolFinal;
        }

        public List<Druzyna> GetZwyciezcyFinal()
        {
            return zwyciezcyFinal;
        }

        public void GenerujlTabliceWynikow()
        {
            // do zrobienia
        }

        public bool zapiszDoPliku()
        {
            return true;
        }
        
        public abstract List<Mecz> GenerujMeczeGrupowe();

        // do zrobienia jebniete tak zeby bledu nie wywalalo
        // dodanie do listy meczów na podstawie listy drużyn, każdy z każdym

            /*
        public abstract List<> GenerujMeczePolFinal();

        // do zrobienia jebniete tak zeby bledu nie wywalalo
        // dodanie do listy meczów na podstawie listy zwycięzów w fazie grupowej

        public abstract List<> GenerujMeczeFinal();
        */
            //do zrobienia jebniete tak zeby bledu nie wywalalo
        
    }
        
}
