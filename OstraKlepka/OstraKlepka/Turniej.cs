using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OstraKlepka
{  
    [Serializable]
    public abstract class Turniej
    {
        protected List<Druzyna> listaDruzyn;
        protected List<Sedzia> listaSedziow;
        // protected List<Druzyna> zwyciezcyGrup;
        // protected List<Druzyna> zwyciezcyPolFinal;
        // protected List<Druzyna> zwyciezcyFinal;
        protected Random random = new Random();
        public List<Druzyna> wynikiGrup;
        public List<Druzyna> wynikiPolfinal;
        public List<Druzyna> wynikiFinal;
      
        public Turniej()
        {

        }
        public Turniej(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow)
        {
            listaDruzyn = new List<Druzyna>(_listaDruzyn);
            listaSedziow = new List<Sedzia>(_listaSedziow);
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

        /*
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
        */
        
        public abstract void GenerujMeczeGrupowe();

        public abstract List<Druzyna>[] GenerujMeczePolFinal(List<Druzyna> _listaDruzyn);
        
        public abstract List<Druzyna>[] GenerujMeczeFinal(List<Druzyna> _listaDruzyn);
        
        
    }
        
}
