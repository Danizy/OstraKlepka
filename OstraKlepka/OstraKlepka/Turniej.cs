using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public class Turniej
    {
        private List<Druzyna> listaDruzyn;
        private List<Sedzia> listaSedziow;
        private List<Sedzia_Pomocniczy> listaSedziowPom;
        // dodać listę meczy
        private List<Druzyna> zwyciezcyGrup;
        private List<Druzyna> zwyciezcyPolFinal;
        private List<Druzyna> zwyciezcyFinal;

        public void SetDruzyny(List<Druzyna> _listaDruzyn)
        {
            listaDruzyn = _listaDruzyn;
        }

        public void SetSedziowie(List<Sedzia> _listaSedziow)
        {
            listaSedziow = _listaSedziow;
        }

        public void SetSedziowiePom(List<Sedzia_Pomocniczy> _listaSedziowPom)
        {
            listaSedziowPom = _listaSedziowPom;
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
            //hihi naklepane hihi
        }
    }
}
