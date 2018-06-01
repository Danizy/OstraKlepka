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
        public Utworz_Turniej(List<Druzyna> listaZawodnikow, List<Sedzia> listaSedziow, List<Sedzia_Pomocniczy> listaSedziowPomocniczych)
        {
            InitializeComponent();
            lv_druzyny.ItemsSource = listaZawodnikow;
            lv_sedziowie.ItemsSource = listaSedziow;
            lv_sedziowie_pom.ItemsSource = listaSedziowPomocniczych;

        }

        private class CheckItem
        {
            public bool isChecked { get; set; }
            public Druzyna druzyna;
        }

        private void Combo_Rodzaj_Turnieju_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Group_Sedziowie_Pom == null)
                return;

            if (Combo_Rodzaj_Turnieju.SelectedIndex != 0)
                Group_Sedziowie_Pom.IsEnabled = false;
            else
                Group_Sedziowie_Pom.IsEnabled = true;

          
        }
    }
}
