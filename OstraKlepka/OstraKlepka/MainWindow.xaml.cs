﻿using System;
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
        public List<Dwa_Ognie> listaMeczyTMP = new List<Dwa_Ognie>();

        public MainWindow()
        {
            InitializeComponent();

            listaDruzyn.Add(new Druzyna("opa"));
            listaDruzyn.Add(new Druzyna("klepka"));
            listaDruzyn.Add(new Druzyna("ostra"));
            listaDruzyn.Add(new Druzyna("oblia"));
            listaDruzyn.Add(new Druzyna("osasdastra"));
            listaDruzyn.Add(new Druzyna("ostr123a"));
            listaDruzyn.Add(new Druzyna("ostraeeee"));
            listaDruzyn.Add(new Druzyna("ostdasdasra"));
            listaDruzyn.Add(new Druzyna("ostr123a"));
            listaDruzyn.Add(new Druzyna("ostraeeee"));
            listaDruzyn.Add(new Druzyna("ostdasdasra"));

            listaDruzyn[0].DodajZawodnika(new Zawodnik("Ahmed", "Abdul", "11"));
            listaDruzyn[0].DodajZawodnika(new Zawodnik("Nuetek", "Abdul", "34"));
            listaDruzyn[0].DodajZawodnika(new Zawodnik("eee", "Aaaal", "1"));
            listaDruzyn[1].DodajZawodnika(new Zawodnik("aaa", "bbb", "22"));
            listaDruzyn[2].DodajZawodnika(new Zawodnik("eeee", "asdasd", "75"));
            listaDruzyn[2].DodajZawodnika(new Zawodnik("Ahsdasdd", "eeea", "13"));

            listaSedziow.Add(new Sedzia("Ahmed", "Abdul", "104012"));
            listaSedziow.Add(new Sedzia("Mietek", "Zul", "101232"));

            listaPomocniczych.Add(new Sedzia_Pomocniczy("Ahmed", "Abdul", "104012"));

            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[0], listaDruzyn[1], listaSedziow[0], "opa"));
            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[4], listaDruzyn[6], listaSedziow[0], "opa"));
            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[5], listaDruzyn[3], listaSedziow[0], "opa"));
            listaMeczyTMP[0].wynik1 = 3;

            //UtworzTabele(listaDruzyn, listaMeczyTMP.Cast<Mecz>().ToList());
            Turniej_Lina turniej = new Turniej_Lina(listaDruzyn, listaSedziow);
            
            turniej.ZapiszDoPliku("turniej",turniej);
            string sciezkaa = "turniej.lin";
           
            Turniej_Lina turniejj = new Turniej_Lina();
            turniejj.OdczytajZPliku<Turniej_Lina>(sciezkaa);
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

        private void UtworzTabele(List<Druzyna> listaDruzyn, List<Mecz> listaMeczy)
        {
            Grid tableGrid = new Grid();
            Grid.SetColumn(tableGrid, 1);
            Grid.SetRow(tableGrid, 1);
            MainGrid.Children.Add(tableGrid);

            //Tworzenie kolumn i wierszy
            foreach (Druzyna d in listaDruzyn)
            {
                tableGrid.ColumnDefinitions.Add(new ColumnDefinition());
                tableGrid.RowDefinitions.Add(new RowDefinition());
            }

            //Dopasowanie rozmiarow okna
            this.Height = 36 * listaDruzyn.Count;
            this.Width = 74 * listaDruzyn.Count;

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
            foreach (Mecz mecz in listaMeczyTMP)
            {
                int idDruzyny1 = listaDruzyn.IndexOf(mecz.getDruzyny()[0]);
                int idDruzyny2 = listaDruzyn.IndexOf(mecz.getDruzyny()[1]);

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
                sp.Children.Add(team1);

                TextBlock a = new TextBlock();
                a.Text = ":";
                a.FontSize = 20;
                a.Margin = new Thickness(2, 0, 2, 5);
                sp.Children.Add(a);


                TextBox team2 = new TextBox();
                team2.MinWidth = 20;
                team2.MaxHeight = 18;
                Binding c = new Binding("wynik2");
                c.Source = mecz;
                c.Mode = BindingMode.TwoWay;
                c.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                c.Converter = new String_Int_Converter();
                team2.SetBinding(TextBox.TextProperty, c);
                sp.Children.Add(team2);

                if (idDruzyny1 > idDruzyny2)
                {
                    Grid.SetColumn(sp, idDruzyny2 + 1);
                    Grid.SetRow(sp, idDruzyny1 - 1);
                }
                else
                {
                    Grid.SetColumn(sp, idDruzyny1 + 1);
                    Grid.SetRow(sp, idDruzyny2 - 1);
                }

                tableGrid.Children.Add(sp);
            }

        }

        private void Menu_utworz_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}