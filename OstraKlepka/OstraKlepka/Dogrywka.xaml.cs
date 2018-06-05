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
    /// Interaction logic for Dogrywka.xaml
    /// </summary>
    public partial class Dogrywka : Window
    {
        Grid tableGrid;
        Turniej turniej;
        List<Mecz> mecze;

        public Dogrywka(List<Druzyna> druzyny, List<Mecz> listaMeczy, Turniej _turniej, int miejscaWolne)
        {
            InitializeComponent();
            turniej = _turniej;
            mecze = listaMeczy;

            UtworzTabele(druzyny, mecze);

            dogrywkaWIndow.Width = druzyny.Count * 30;
            dogrywkaWIndow.Height = druzyny.Count * 30;
        }

        private void UtworzTabele(List<Druzyna> listaDruzyn, List<Mecz> listaMeczy)
        {
            tableGrid = new Grid();
            Grid.SetColumn(tableGrid, 1);
            Grid.SetRow(tableGrid, 1);
            MainGrid.Children.Add(tableGrid);
            string[] kolumnaNazwDruzyn = new string[listaDruzyn.Count];

            //Tworzenie kolumn i wierszy
            foreach (Druzyna d in listaDruzyn)
            {
                //RowDefinition row = new RowDefinition();
                //row.Height = new GridLength(1, GridUnitType.Auto);
                tableGrid.ColumnDefinitions.Add(new ColumnDefinition());
                tableGrid.RowDefinitions.Add(new RowDefinition());
            }

            //Dopasowanie rozmiarow okna
            this.Height = 46 * listaDruzyn.Count;
            this.Width = 84 * listaDruzyn.Count;

            //Wypelnienie nazw druzyn
            for (int i = 0; i < listaDruzyn.Count; i++)
            {
                if (i > 0)
                {
                    TextBlock nazwa = new TextBlock();
                    nazwa.Text = listaDruzyn[i].nazwa;
                    nazwa.HorizontalAlignment = HorizontalAlignment.Center;
                    nazwa.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(nazwa, 0);
                    Grid.SetRow(nazwa, i - 1);
                    tableGrid.Children.Add(nazwa);
                    kolumnaNazwDruzyn[i - 1] = listaDruzyn[i].nazwa;
                }

                if (i < listaDruzyn.Count - 1)
                {
                    TextBlock nazwa = new TextBlock();
                    nazwa.Text = listaDruzyn[i].nazwa;
                    nazwa.HorizontalAlignment = HorizontalAlignment.Center;
                    nazwa.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(nazwa, i + 1);
                    Grid.SetRow(nazwa, listaDruzyn.Count - 1);
                    tableGrid.Children.Add(nazwa);
                }

            }

            //Tworzenie komorek poszczegolnych meczy
            foreach (Mecz mecz in listaMeczy)
            {
                int idDruzyny1 = listaDruzyn.IndexOf(mecz.GetDruzyny()[0]);
                int idDruzyny2 = listaDruzyn.IndexOf(mecz.GetDruzyny()[1]);

                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                sp.HorizontalAlignment = HorizontalAlignment.Center;
                sp.VerticalAlignment = VerticalAlignment.Center;

                TextBox team1 = new TextBox();
                team1.MinWidth = 20;
                team1.MaxHeight = 18;
                Binding b = new Binding("wynik1");
                b.Source = mecz;
                b.Mode = BindingMode.TwoWay;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Converter = new String_Int_Converter();
                team1.SetBinding(TextBox.TextProperty, b);

                TextBlock a = new TextBlock();
                a.Text = ":";
                a.FontSize = 20;
                a.Margin = new Thickness(2, 0, 2, 5);


                TextBox team2 = new TextBox();
                team2.MinWidth = 20;
                team2.MaxHeight = 18;
                Binding c = new Binding("wynik2");
                c.Source = mecz;
                c.Mode = BindingMode.TwoWay;
                c.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                c.Converter = new String_Int_Converter();
                team2.SetBinding(TextBox.TextProperty, c);



                if (idDruzyny1 > idDruzyny2)
                {
                    Grid.SetColumn(sp, idDruzyny2 + 1);
                    Grid.SetRow(sp, idDruzyny1 - 1);

                    if (mecz.GetDruzyny()[0].nazwa == kolumnaNazwDruzyn[idDruzyny1 - 1])
                    {
                        sp.Children.Add(team1);
                        sp.Children.Add(a);
                        sp.Children.Add(team2);
                    }
                    else
                    {
                        sp.Children.Add(team2);
                        sp.Children.Add(a);
                        sp.Children.Add(team1);
                    }
                }
                else
                {
                    Grid.SetColumn(sp, idDruzyny1 + 1);
                    Grid.SetRow(sp, idDruzyny2 - 1);

                    if (mecz.GetDruzyny()[0].nazwa == kolumnaNazwDruzyn[idDruzyny2 - 1])
                    {
                        sp.Children.Add(team1);
                        sp.Children.Add(a);
                        sp.Children.Add(team2);
                    }
                    else
                    {
                        sp.Children.Add(team2);
                        sp.Children.Add(a);
                        sp.Children.Add(team1);
                    }
                }



                tableGrid.Children.Add(sp);
            }

        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if(turniej is Turniej_DwaOgnie)
            {
                Turniej_DwaOgnie DwaTurniej = turniej as Turniej_DwaOgnie;
                List<Druzyna> wyniki = DwaTurniej.GenerujTabliceWynikow(mecze.Cast<Dwa_Ognie>().ToList());

                if(wyniki.Count > 1)
                {

                }
            }
        }
    }
}
