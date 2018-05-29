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
    /// Interaction logic for Zarzadzaj_Druzynami.xaml
    /// </summary>
    public partial class Zarzadzaj_Druzynami : Window
    {
        List<Druzyna> listaDruzyn;
        List<Zawodnik> listaZawodnikow;

        public Zarzadzaj_Druzynami(List<Druzyna> _listaDruzyn, List<Zawodnik> _listaZawodnikow)
        {
            InitializeComponent();
            listaDruzyn = _listaDruzyn;
            listaZawodnikow = _listaZawodnikow;
            lv_druzyny.ItemsSource = listaDruzyn;
        }

        private void lv_druzyny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lv_zawodnicy.ItemsSource = listaDruzyn[lv_druzyny.SelectedIndex].GetZawodnicy();
            lv_zawodnicy.Items.Refresh();
        }

        private void Druzyna_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodaj_Druzyne dodajDruzyne = new Dodaj_Druzyne();
            dodajDruzyne.Owner = this;
            dodajDruzyne.ShowDialog();

            if (dodajDruzyne.DialogResult.HasValue && dodajDruzyne.DialogResult.Value)
            {
                listaDruzyn.Add(new Druzyna(dodajDruzyne.nazwa));
            }

            dodajDruzyne = null;
            lv_druzyny.Items.Refresh();
        }

        private void Druzyna_Usun_Click(object sender, RoutedEventArgs e)
        {
            if (lv_druzyny.SelectedIndex == -1)
                return;

            listaDruzyn.RemoveAt(lv_druzyny.SelectedIndex);
            lv_druzyny.Items.Refresh();
        }
    }
}
