using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstraKlepka
{
    public class NiewlasciwyFormat_Exception : Exception
    {
        public NiewlasciwyFormat_Exception()
        {

        }

        public NiewlasciwyFormat_Exception(string wiadomosc)
            :base(wiadomosc)
        {
        }


    }
}
