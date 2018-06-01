using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OstraKlepka
{
    /// <summary>
    /// Interaction logic for Utworz_Turniej.xaml
    /// </summary>
    public partial class Utworz_Turniej : Window
    {
        public Utworz_Turniej(List<Zawodnik> listaZawodnikow)
        {
            InitializeComponent();
        }

        private class CheckItem
        {
            public bool isChecked { get; set; }
            public Zawodnik zawodnik;
        }
    }
}
