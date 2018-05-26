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

        public MainWindow()
        {
            InitializeComponent();

            listaDruzyn.Add(new Druzyna("opa"));
            listaDruzyn.Add(new Druzyna("klepka"));
            listaDruzyn.Add(new Druzyna("ostra"));

            listaSedziow.Add(new Sedzia("Ahmed", "Abdul", "104012"));
            listaSedziow.Add(new Sedzia("Mietek", "Zul", "101232"));

        }

        private void Menu_sedziowie_Click(object sender, RoutedEventArgs e)
        {
            Zarzadzaj_Sedziami oknoSedziowie = new Zarzadzaj_Sedziami(listaSedziow);
            oknoSedziowie.listaSedziow = listaSedziow;
            oknoSedziowie.ShowDialog();

            if (oknoSedziowie.DialogResult.HasValue && oknoSedziowie.DialogResult.Value)
            {
                listaSedziow = oknoSedziowie.listaSedziow;
            }
            oknoSedziowie = null;
        }
    }
}
