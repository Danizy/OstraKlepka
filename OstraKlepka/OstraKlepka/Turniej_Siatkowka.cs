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
        public Turniej_Siatkowka (List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow, List<Sedzia_Pomocniczy> _listaSedziowPom, 
                                  List<Mecz> _listaMeczow, List<Druzyna> _zwyciezcyGrup, List<Druzyna> _zwyciezcyPolFinal, 
                                  List<Druzyna> _zwyciezcyFinal):base(_listaDruzyn, _listaSedziow, _listaMeczow, _zwyciezcyGrup, 
                                  _zwyciezcyPolFinal, _zwyciezcyFinal)
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

        public List<Siatkowka> GenerujMeczeGrupowe()
        {
            for (int i = 0; i < listaDruzyn.Count - 1 ; i++)
            {
                listaMeczow.Add(new Siatkowka(listaDruzyn[i], listaDruzyn[i + 1], listaSedziow[random.Next(listaSedziow.Count)],
                                                       listaSedziowPom[random.Next(listaSedziowPom.Count)], listaSedziowPom[random.Next(listaSedziowPom.Count)],
                                                       "grupowy"));
            }


            return listaMeczowSiatkowki;
            //do zrobienia
            
        }
       /* override public List<Siatkowka> GenerujMeczePolFinal()
        {
            //do zrobienia
            return listaMeczowSiatkowki;
        }
        override public List<Siatkowka> GenerujMeczeFinal()
        {
            //do zrobienia
            
        }
        */
       
    }
}
