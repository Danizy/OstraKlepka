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
    /// Interaction logic for Dodaj_Druzyne.xaml
    /// </summary>
    public partial class Dodaj_Druzyne : Window
    {
        public string nazwa;

        public Dodaj_Druzyne()
        {
            InitializeComponent();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            nazwa = nazwaTextBox.Text;
            this.DialogResult = true;
            this.Close();
        }
    }
}
