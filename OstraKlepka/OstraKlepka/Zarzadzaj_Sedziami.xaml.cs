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
        public List<Druzyna> listaDruzyn;
        private ObservableCollection<Druzyna> listaDruzyn2;


        public Zarzadzaj_Sedziami(List<Druzyna> _listaDruzyn)
        {
           
            InitializeComponent();

            listaDruzyn = _listaDruzyn;
            initBind();

            
        }

        private void initBind()
        {
            listaDruzyny.ItemsSource = listaDruzyn;
        }

        private void Druzyna_Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodaj_Druzyne dodajDruzyne = new Dodaj_Druzyne();
            dodajDruzyne.ShowDialog();

            if (dodajDruzyne.DialogResult.HasValue && dodajDruzyne.DialogResult.Value)
            {
                listaDruzyn.Add(new Druzyna(dodajDruzyne.nazwa));
                listaDruzyny.Items.Refresh();
                
            }
            dodajDruzyne = null;
        }
    }
}
