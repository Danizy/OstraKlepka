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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OstraKlepka
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Druzyna> listaDruzyn = new List<Druzyna>();
        public List<Sedzia> listaSedziow = new List<Sedzia>();
        public List<Sedzia_Pomocniczy> listaPomocniczych = new List<Sedzia_Pomocniczy>();
        public List<Zawodnik> listaZawodnikow = new List<Zawodnik>();

        public MainWindow()
        {
            InitializeComponent();

            listaDruzyn.Add(new Druzyna("opa"));
            listaDruzyn.Add(new Druzyna("klepka"));
            listaDruzyn.Add(new Druzyna("ostra"));

            listaDruzyn[0].DodajZawodnika(new Zawodnik("Ahmed", "Abdul", "11"));
            listaDruzyn[0].DodajZawodnika(new Zawodnik("Nuetek", "Abdul", "34"));
            listaDruzyn[0].DodajZawodnika(new Zawodnik("eee", "Aaaal", "1"));
            listaDruzyn[1].DodajZawodnika(new Zawodnik("aaa", "bbb", "22"));
            listaDruzyn[2].DodajZawodnika(new Zawodnik("eeee", "asdasd", "75"));
            listaDruzyn[2].DodajZawodnika(new Zawodnik("Ahsdasdd", "eeea", "13"));

            listaSedziow.Add(new Sedzia("Ahmed", "Abdul", "104012"));
            listaSedziow.Add(new Sedzia("Mietek", "Zul", "101232"));

            listaPomocniczych.Add(new Sedzia_Pomocniczy("Ahmed", "Abdul", "104012"));


        }

        private void Menu_sedziowie_Click(object sender, RoutedEventArgs e)
        {
            Zarzadzaj_Sedziami oknoSedziowie = new Zarzadzaj_Sedziami(listaSedziow, listaPomocniczych);
            oknoSedziowie.Owner = this;
            oknoSedziowie.ShowDialog();
            oknoSedziowie = null;
        }

        private void Menu_druzyny_Click(object sender, RoutedEventArgs e)
        {
            Zarzadzaj_Druzynami oknoDruzyny = new Zarzadzaj_Druzynami(listaDruzyn, listaZawodnikow);
            oknoDruzyny.Owner = this;
            oknoDruzyny.ShowDialog();
            oknoDruzyny = null;
        }
    }
}
