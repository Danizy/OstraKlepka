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
            if (lv_druzyny.SelectedIndex == -1)
            {
                lv_zawodnicy.ItemsSource = null;
                return;
            }

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

        private void Druzyna_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            if (lv_druzyny.SelectedIndex == -1)
                return;

            Dodaj_Druzyne dodajDruzyne = new Dodaj_Druzyne();
            dodajDruzyne.Owner = this;
            dodajDruzyne.TextBlk.Text = "Edytuj nazwe druzyny";
            dodajDruzyne.nazwaTextBox.Text = listaDruzyn[lv_druzyny.SelectedIndex].nazwa;
            dodajDruzyne.ShowDialog();

            if (dodajDruzyne.DialogResult.HasValue && dodajDruzyne.DialogResult.Value)
            {
                listaDruzyn[lv_druzyny.SelectedIndex].nazwa = dodajDruzyne.nazwaTextBox.Text;
            }

            dodajDruzyne = null;
            lv_druzyny.Items.Refresh();
        }

        private void Zawodnik_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (lv_druzyny.SelectedIndex == -1)
                return;

            Dodaj_Zawodnika dodajZawodnika = new Dodaj_Zawodnika();
            dodajZawodnika.Owner = this;
            dodajZawodnika.ShowDialog();

            if (dodajZawodnika.DialogResult.HasValue && dodajZawodnika.DialogResult.Value)
            {
                listaDruzyn[lv_druzyny.SelectedIndex].DodajZawodnika(dodajZawodnika.zawodnik);
            }

            dodajZawodnika = null;
            lv_zawodnicy.Items.Refresh();
        }

        private void Zawodnik_Usun_Click(object sender, RoutedEventArgs e)
        {
            if (lv_druzyny.SelectedIndex == -1 || lv_zawodnicy.SelectedIndex == -1)
                return;

           
        }
    }
}
