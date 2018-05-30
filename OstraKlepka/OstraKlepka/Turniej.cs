using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public abstract class Turniej
    {
        private List<Druzyna> listaDruzyn;
        private List<Sedzia> listaSedziow;
        private List<Sedzia_Pomocniczy> listaSedziowPom;
        private List<Mecz> listaMeczow;
        private List<Druzyna> zwyciezcyGrup;
        private List<Druzyna> zwyciezcyPolFinal;
        private List<Druzyna> zwyciezcyFinal;
      

        public Turniej(List<Druzyna> _listaDruzyn,List<Sedzia> _listaSedziow,List<Sedzia_Pomocniczy> _listaSedziowPom,List<Mecz> _listaMeczow, List<Druzyna> _zwyciezcyGrup, List<Druzyna> _zwyciezcyPolFinal, List<Druzyna> _zwyciezcyFinal)
        {
            listaDruzyn = new List<Druzyna>(_listaDruzyn);
            listaSedziow = new List<Sedzia>(_listaSedziow);
            listaSedziowPom = new List<Sedzia_Pomocniczy>(_listaSedziowPom);
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

        public void SetSedziowiePom(List<Sedzia_Pomocniczy> _listaSedziowPom)
        {
            listaSedziowPom = new List<Sedzia_Pomocniczy>(_listaSedziowPom);
        }

        public List<Druzyna> GetDruzyny()
        {
            return listaDruzyn;
        }

        public List<Sedzia> GetSedziowie()
        {
            return listaSedziow;
        }

        public List<Sedzia_Pomocniczy> GetSedziowiePom()
        {
            return listaSedziowPom;
        }

        public void addZwyciezceGrup(Druzyna _druzyna)
        {
            zwyciezcyGrup.Add(new Druzyna(_druzyna));
        }

        public void addZwyciezcePolFinal(Druzyna _druzyna)
        {
            zwyciezcyPolFinal.Add(new Druzyna(_druzyna));
        }

        public void addZwyciezceFinal(Druzyna _druzyna)
        {
            zwyciezcyFinal.Add(new Druzyna(_druzyna));
        }

        public List<Druzyna> getZwyciezcyGrup()
        {
            return zwyciezcyGrup;
        }

        public List<Druzyna> getZwyciezcyPolFinal()
        {
            return zwyciezcyPolFinal;
        }

        public List<Druzyna> getZwyciezcyFinal()
        {
            return zwyciezcyFinal;
        }

        public void generujlTabliceWynikow()
        {
            // do zrobienia
        }

        public bool zapiszDoPliku()
        {
            return true;
        }

        public virtual List<Mecz> generujMeczeGrupowe()
        {
            // do zrobienia jebniete tak zeby bledu nie wywalalo
            // dodanie do listy meczów na podstawie listy drużyn, każdy z każdym
            return listaMeczow;
        }

        public virtual List<Mecz> generujMeczePolFinal()
        {
            // do zrobienia jebniete tak zeby bledu nie wywalalo
            // dodanie do listy meczów na podstawie listy zwycięzów w fazie grupowej
            return listaMeczow;
        }

        public virtual List<Mecz> generujMeczeFinal()
        {
            //do zrobienia jebniete tak zeby bledu nie wywalalo
            return listaMeczow;
        }

    }
}
