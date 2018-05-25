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
    /// Logika interakcji dla klasy Zarzadzaj_Sedziami.xaml
    /// </summary>
    public partial class Zarzadzaj_Sedziami : Window
    {
        public string opa;


        public Zarzadzaj_Sedziami()
        {
           
            InitializeComponent();

            
        }

        private void Slij_Click(object sender, RoutedEventArgs e)
        {
            this.opa = "blin";
            this.DialogResult = true;
            this.Close();
        }

        public void SetData(List<Druzyna> _listaDruzyn)
        {

        }
    }
}
