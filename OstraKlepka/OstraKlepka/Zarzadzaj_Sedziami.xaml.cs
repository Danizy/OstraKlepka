using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy Zarzadzaj_Sedziami.xaml
    /// </summary>
    public partial class Zarzadzaj_Sedziami : Window
    {
        public List<Sedzia> listaSedziow;
        public List<Sedzia_Pomocniczy> listaPomocniczych;


        public Zarzadzaj_Sedziami(List<Sedzia> _listaSedziow, List<Sedzia_Pomocniczy> _listaPomocniczych)
        {
           
            InitializeComponent();

            listaSedziow = _listaSedziow;
            listaPomocniczych = _listaPomocniczych;
            initBind();

            
        }

        private void initBind()
        {
            listaSedziowie.ItemsSource = listaSedziow;
            listaSedziowiePom.ItemsSource = listaPomocniczych;
        }

        private void Druzyna_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajSedziego dodajSedziego = new DodajSedziego();
            dodajSedziego.Owner = this;
            dodajSedziego.ShowDialog();

            if (dodajSedziego.DialogResult.HasValue && dodajSedziego.DialogResult.Value)
            {
                if (dodajSedziego.isPomocniczy)
                {
                    listaPomocniczych.Add(new Sedzia_Pomocniczy((Sedzia_Pomocniczy)dodajSedziego.sedzia));
                    listaSedziowiePom.Items.Refresh();
                }
                else
                {
                    listaSedziow.Add(new Sedzia(dodajSedziego.sedzia));
                    listaSedziowie.Items.Refresh();
                }
                
                
            }
            dodajSedziego = null;
        }

        private void Sedzia_Usun_Click(object sender, RoutedEventArgs e)
        {
            listaSedziow.RemoveAt(listaSedziowie.SelectedIndex);
            listaSedziowie.Items.Refresh();
        }

        private void Sedzia_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            DodajSedziego dodajSedziego = new DodajSedziego();
            dodajSedziego.imieTextBox.Text = listaSedziow[listaSedziowie.SelectedIndex].imie;
            dodajSedziego.nazwiskoTextBox.Text = listaSedziow[listaSedziowie.SelectedIndex].nazwisko;
            dodajSedziego.idTextBox.Text = listaSedziow[listaSedziowie.SelectedIndex].id;
            dodajSedziego.btnText.Text = "Zapisz";
            dodajSedziego.Title = "Edytuj sędziego";
            dodajSedziego.Owner = this;
            dodajSedziego.ShowDialog();

            if (dodajSedziego.DialogResult.HasValue && dodajSedziego.DialogResult.Value)
            {
                if (dodajSedziego.isPomocniczy)
                {

                }
                else
                {
                    listaSedziow[listaSedziowie.SelectedIndex].imie = dodajSedziego.sedzia.imie;
                    listaSedziow[listaSedziowie.SelectedIndex].nazwisko = dodajSedziego.sedzia.nazwisko;
                    listaSedziow[listaSedziowie.SelectedIndex].id = dodajSedziego.sedzia.id;
                }
                listaSedziowie.Items.Refresh();

            }
            dodajSedziego = null;
        }

        private void SedziaPom_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajSedziego dodajSedziego = new DodajSedziego();
            dodajSedziego.Owner = this;
            dodajSedziego.pomocniczy.IsChecked = true;
            dodajSedziego.ShowDialog();

            if (dodajSedziego.DialogResult.HasValue && dodajSedziego.DialogResult.Value)
            {
                if (dodajSedziego.isPomocniczy)
                {
                    listaPomocniczych.Add(new Sedzia_Pomocniczy((Sedzia_Pomocniczy)dodajSedziego.sedzia));
                    listaSedziowiePom.Items.Refresh();
                }
                else
                {
                    listaSedziow.Add(new Sedzia(dodajSedziego.sedzia));
                    listaSedziowie.Items.Refresh();
                }
                

            }
            dodajSedziego = null;
        }
    }
}
