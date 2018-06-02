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
        public List<Druzyna> listaDruzyn = new List<Druzyna>();
        public List<Sedzia> listaSedziow = new List<Sedzia>();
        public List<Sedzia_Pomocniczy> listaSedziowPomocniczych = new List<Sedzia_Pomocniczy>();
        public int typTurnieju = 0;

        public Utworz_Turniej(List<Druzyna> _listaDruzyn, List<Sedzia> _listaSedziow, List<Sedzia_Pomocniczy> _listaSedziowPomocniczych)
        {
            InitializeComponent();

            lv_druzyny.ItemsSource = _listaDruzyn;
            lv_sedziowie.ItemsSource = _listaSedziow;
            lv_sedziowie_pom.ItemsSource = _listaSedziowPomocniczych;
        }

        private void Combo_Rodzaj_Turnieju_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Group_Sedziowie_Pom == null)
                return;

            if (Combo_Rodzaj_Turnieju.SelectedIndex != 0)
            {
                Group_Sedziowie_Pom.IsEnabled = false;
                if (lv_druzyny.SelectedItems.Count < 5 || lv_sedziowie.SelectedItems.Count < 1)
                    Btn_Utworz.IsEnabled = false;
                else
                    Btn_Utworz.IsEnabled = true;
            }

            else
            {
                Group_Sedziowie_Pom.IsEnabled = true;
                if (Combo_Rodzaj_Turnieju.SelectedIndex == 0 && (lv_druzyny.SelectedItems.Count < 5 || lv_sedziowie.SelectedItems.Count < 1 || lv_sedziowie_pom.SelectedItems.Count < 2))
                    Btn_Utworz.IsEnabled = false;
                else
                    Btn_Utworz.IsEnabled = true;
            }

          
        }

        private void lv_druzyny_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Combo_Rodzaj_Turnieju.SelectedIndex == 0 && (lv_druzyny.SelectedItems.Count < 5 || lv_sedziowie.SelectedItems.Count < 1 || lv_sedziowie_pom.SelectedItems.Count < 2))
            {
                Btn_Utworz.IsEnabled = false;
                return;
            }
            if(lv_druzyny.SelectedItems.Count < 5 || lv_sedziowie.SelectedItems.Count < 1)
            {
                Btn_Utworz.IsEnabled = false;
                return;
            }
            Btn_Utworz.IsEnabled = true;
        }

        private void Btn_Utworz_Click(object sender, RoutedEventArgs e)
        {
            foreach(Druzyna druzyna in lv_druzyny.SelectedItems)
            {
                listaDruzyn.Add(druzyna);
            }

            foreach (Sedzia sedzia in lv_sedziowie.SelectedItems)
            {
                listaSedziow.Add(sedzia);
            }

            foreach (Sedzia_Pomocniczy sedziaPom in lv_sedziowie_pom.SelectedItems)
            {
                listaSedziowPomocniczych.Add(sedziaPom);
            }

            typTurnieju = Combo_Rodzaj_Turnieju.SelectedIndex;

            this.DialogResult = true;
            this.Close();
        }
    }
}
