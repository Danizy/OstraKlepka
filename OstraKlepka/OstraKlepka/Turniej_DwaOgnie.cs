﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    class Turniej_DwaOgnie : Turniej
    {
       public Turniej_DwaOgnie(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow):base(_listaDruzyn,  _listaSedziow)
        {

        }

        public override void GenerujMeczeGrupowe()
        {
   
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
