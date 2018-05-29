using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DodajSedziego.xaml
    /// </summary>
    public partial class DodajSedziego : Window
    {

        public bool isPomocniczy = false;
        public Sedzia sedzia;

        public DodajSedziego()
        {
            InitializeComponent();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^([A-Za-ząćęółźżń])*$");

            if (!regex.Match(imieTextBox.Text).Success || !regex.Match(nazwiskoTextBox.Text).Success || imieTextBox.Text == "" || nazwiskoTextBox.Text == "")
            {
                MessageBox.Show("Imie lub nazwisko zawiera niedozwolone znaki", "Blad", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            regex = new Regex(@"^[0-9]*$");

            if (!regex.Match(idTextBox.Text).Success || idTextBox.Text == "")
            {
                MessageBox.Show("Id moze zawierac tylko cyfry", "Blad", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
                

            sedzia = new Sedzia(imieTextBox.Text, nazwiskoTextBox.Text, idTextBox.Text);
            if (pomocniczy.IsChecked.Value)
            {
                isPomocniczy = true;
                sedzia = new Sedzia_Pomocniczy(imieTextBox.Text, nazwiskoTextBox.Text, idTextBox.Text);
            }
                

            this.DialogResult = true;
            this.Close();
        }
    }
}
