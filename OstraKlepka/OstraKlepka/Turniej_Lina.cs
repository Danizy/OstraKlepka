using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    class Turniej_Lina:Turniej
    {
      public  Turniej_Lina(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow, List<Mecz> _listaMeczow, List<Druzyna> _zwyciezcyGrup, List<Druzyna> _zwyciezcyPolFinal, List<Druzyna> _zwyciezcyFinal):base(_listaDruzyn, _listaSedziow, _listaMeczow, _zwyciezcyGrup, _zwyciezcyPolFinal, _zwyciezcyFinal)
        {

        }
    }
}
