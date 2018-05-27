﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public abstract class Mecz
    {
        private Druzyna[] druzyna = new Druzyna[2];
        private Sedzia sedzia;
        private int[] wynik = new int[2];
        private string rodzajMeczu;

        protected Mecz(Druzyna druzyna1, Druzyna druzyna2, Sedzia _sedzia, string _rodzajMeczu)
        {
            druzyna[0] = druzyna1;
            druzyna[1] = druzyna2;
            sedzia = _sedzia;
            rodzajMeczu = _rodzajMeczu;
        }

        public void setDruzyny(Druzyna druzyna1, Druzyna druzyna2)
        {
            druzyna[0] = druzyna1;
            druzyna[1] = druzyna2;
        }

        public void setSedzia(Sedzia _sedzia)
        {
            sedzia = _sedzia;
        }

        public void setWynik(int wynik1, int wynik2)
        {
            wynik[0] = wynik1;
            wynik[1] = wynik2;
        } 

        public void setRodzajMeczu(string _rodzajMeczu)
        {
            rodzajMeczu = _rodzajMeczu;
        }

        public Druzyna[] getDruzyny()
        {
            return druzyna;
        }

        public Sedzia getSedzia()
        {
            return sedzia;
        }

        public int[] getWynik()
        {
            return wynik;
        }

        public string getRodzajMeczu()
        {
            return rodzajMeczu;
        }

        public Druzyna getZwyciezca()
        {
            if(wynik[0] > wynik[1])
            {
                return druzyna[0];
            }
            else if(wynik[0] < wynik[1])
            {
                return druzyna[1];
            }
            else
            {
                return null;
            }
        }
    }
}