﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    class Turniej_DwaOgnie:Turniej
    {
       public Turniej_DwaOgnie(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow, List<Sedzia_Pomocniczy> _listaSedziowPom, List<Mecz> _listaMeczow, List<Druzyna> _zwyciezcyGrup, List<Druzyna> _zwyciezcyPolFinal, List<Druzyna> _zwyciezcyFinal):base (_listaDruzyn,  _listaSedziow, _listaSedziowPom, _listaMeczow,  _zwyciezcyGrup, _zwyciezcyPolFinal,  _zwyciezcyFinal)
        {

        }
    }

}
