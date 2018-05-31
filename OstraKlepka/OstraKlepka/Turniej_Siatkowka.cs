using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    class Turniej_Siatkowka : Turniej
    {
        private List<Siatkowka> listaMeczowSiatkowki;
        private List<Sedzia_Pomocniczy> listaSedziowPom;
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

        public override void GenerujMeczeGrupowe()
        {
            for (int i = 0; i < listaDruzyn.Count - 1 ; i++)
            {
                listaMeczowSiatkowki.Add(new Siatkowka(listaDruzyn[i], listaDruzyn[i + 1], listaSedziow[random.Next(listaSedziow.Count)],
                                                       listaSedziowPom[random.Next(listaSedziowPom.Count)], listaSedziowPom[random.Next(listaSedziowPom.Count)],
                                                       "grupowy"));
            }

            //do zrobienia
            
        }
        override public void GenerujMeczePolFinal()
        {
            //do zrobienia
        }
        override public void GenerujMeczeFinal()
        {
            //do zrobienia
            
        }
        
       
    }
}
