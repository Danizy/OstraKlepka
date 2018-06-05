using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        public Turniej_DwaOgnie turniejTest = new Turniej_DwaOgnie();
        public Turniej tmpTurniej;
        public Grid tableGrid; // Uchwyt do tabeli wynikow NIE RUSZAC
        public List<Druzyna>[] listaTest = new List<Druzyna>[2];

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

            listaDruzyn[0].DodajZawodnika(new Zawodnik("Ahmed", "Abdul", "11"));
            listaDruzyn[0].DodajZawodnika(new Zawodnik("Nuetek", "Abdul", "34"));
            listaDruzyn[0].DodajZawodnika(new Zawodnik("eee", "Aaaal", "1"));
            listaDruzyn[1].DodajZawodnika(new Zawodnik("aaa", "bbb", "22"));
            listaDruzyn[2].DodajZawodnika(new Zawodnik("eeee", "asdasd", "75"));
            listaDruzyn[2].DodajZawodnika(new Zawodnik("Ahsdasdd", "eeea", "13"));

            listaSedziow.Add(new Sedzia("Ahmed", "Abdul", "104012"));
            listaSedziow.Add(new Sedzia("Mietek", "Zul", "101232"));

            listaPomocniczych.Add(new Sedzia_Pomocniczy("Ahmed", "Abdul", "104012"));
            listaPomocniczych.Add(new Sedzia_Pomocniczy("Ahmeeeed", "Abdsul", "12312"));

            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[0], listaDruzyn[1], listaSedziow[0], "opa"));
            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[4], listaDruzyn[6], listaSedziow[0], "opa"));
            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[5], listaDruzyn[3], listaSedziow[0], "opa"));
            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[4], listaDruzyn[3], listaSedziow[0], "opa"));
            listaMeczyTMP.Add(new Dwa_Ognie(listaDruzyn[5], listaDruzyn[3], listaSedziow[0], "opa"));
            listaMeczyTMP[0].wynik1 = 3;
            listaMeczyTMP[1].wynik2 = 3;
            listaMeczyTMP[2].wynik1 = 3;

            turniejTest = new Turniej_DwaOgnie(listaDruzyn, listaSedziow);
            turniejTest.GenerujMeczeGrupowe();
            listaTest = turniejTest.GenerujMeczePolFinal();
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

        private void Menu_utworz_Click(object sender, RoutedEventArgs e)
        {
            Utworz_Turniej utworzTurniej = new Utworz_Turniej(listaDruzyn, listaSedziow, listaPomocniczych);
            utworzTurniej.Owner = this;
            utworzTurniej.ShowDialog();

            if (utworzTurniej.DialogResult.HasValue && utworzTurniej.DialogResult.Value)
            {
                if (utworzTurniej.typTurnieju == 0)
                    tmpTurniej = new Turniej_Siatkowka(utworzTurniej.listaDruzyn, utworzTurniej.listaSedziow, utworzTurniej.listaSedziowPomocniczych);
                else if (utworzTurniej.typTurnieju == 1)
                    tmpTurniej = new Turniej_DwaOgnie(utworzTurniej.listaDruzyn, utworzTurniej.listaSedziow);
                else
                    tmpTurniej = new Turniej_Lina(utworzTurniej.listaDruzyn, utworzTurniej.listaSedziow);
            }
            utworzTurniej = null;

            MainGrid.Children.RemoveAt(1);

            if (tmpTurniej is Turniej_Siatkowka)
            {
                Turniej_Siatkowka turniej = tmpTurniej as Turniej_Siatkowka;
                turniej.GenerujMeczeGrupowe();
                UtworzTabele(turniej.GetDruzyny(), turniej.GetListaMeczowSiatkowki().Cast<Mecz>().ToList());
            }

            else if (tmpTurniej is Turniej_DwaOgnie)
            {
                Turniej_DwaOgnie turniej = tmpTurniej as Turniej_DwaOgnie;
                turniej.GenerujMeczeGrupowe();
                UtworzTabele(turniej.GetDruzyny(), turniej.GetListaMeczowDwaOgnie().Cast<Mecz>().ToList());
            }
            else
            {
                Turniej_Lina turniej = tmpTurniej as Turniej_Lina;
                turniej.GenerujMeczeGrupowe();
                UtworzTabele(turniej.GetDruzyny(), turniej.GetListaMeczowLina().Cast<Mecz>().ToList());
            }
            

            Btn_Generuj.Visibility = Visibility.Visible;
            Btn_Wyswietl_Wyniki.Visibility = Visibility.Visible;


        }

        private void Menu_wczytaj_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.Children.IndexOf(ImgLogo) != -1)
                MainGrid.Children.Remove(ImgLogo);
            else if (MainGrid.Children.IndexOf(tableGrid) != -1)
                MainGrid.Children.Remove(tableGrid);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Turniej (*.sia, *.ogn, *.lin)|*.sia; *.ogn; *.lin";
            if (openFileDialog.ShowDialog() == true)
            {
                if(System.IO.Path.GetExtension(openFileDialog.FileName) == ".sia")
                {
                    tmpTurniej = new Turniej_Siatkowka();
                    Turniej_Siatkowka turniej = tmpTurniej as Turniej_Siatkowka;
                    turniej.OdczytajZPliku(openFileDialog.FileName);
                    UtworzTabele(turniej.GetDruzyny(), turniej.GetListaMeczowSiatkowki().Cast<Mecz>().ToList());
                }
                else if(System.IO.Path.GetExtension(openFileDialog.FileName) == ".lin")
                {
                    tmpTurniej = new Turniej_Lina();
                    Turniej_Lina turniej = tmpTurniej as Turniej_Lina;
                    turniej.OdczytajZPliku(openFileDialog.FileName);
                    UtworzTabele(turniej.GetDruzyny(), turniej.GetListaMeczowLina().Cast<Mecz>().ToList());
                }
                else
                {
                    tmpTurniej = new Turniej_DwaOgnie();
                    Turniej_DwaOgnie turniej = tmpTurniej as Turniej_DwaOgnie;
                    turniej.OdczytajZPliku(openFileDialog.FileName);
                    UtworzTabele(turniej.GetDruzyny(), turniej.GetlistaDwaOgnie().Cast<Mecz>().ToList());
                }

                Btn_Generuj.Visibility = Visibility.Visible;
                Btn_Wyswietl_Wyniki.Visibility = Visibility.Visible;
            }
        }

        private void Btn_Generuj_Click(object sender, RoutedEventArgs e)
        {


            Turniej_DwaOgnie turniej = tmpTurniej as Turniej_DwaOgnie;
            List<Druzyna>[] opa = new List<Druzyna>[2];
            opa = turniej.GenerujMeczePolFinal();





        }

        private void Btn_Wyswietl_Wyniki_Click(object sender, RoutedEventArgs e)
        {
            TabelaWynikow tabelaWynikow;

            if (tmpTurniej is Turniej_Siatkowka)
            {
                Turniej_Siatkowka turniej = tmpTurniej as Turniej_Siatkowka;
                tabelaWynikow = new TabelaWynikow(turniej.GenerujTabliceWynikow(turniej.listaMeczowSiatkowki), tmpTurniej);
                tabelaWynikow.Owner = this;
                tabelaWynikow.ShowDialog();
            }
            else if(tmpTurniej is Turniej_Lina)
            {
                Turniej_Lina turniej = tmpTurniej as Turniej_Lina;
                tabelaWynikow = new TabelaWynikow(turniej.GenerujTabliceWynikow(turniej.listaPrzeciaganieLiny), tmpTurniej);
                tabelaWynikow.Owner = this;
                tabelaWynikow.ShowDialog();
            }
            else
            {
                Turniej_DwaOgnie turniej = tmpTurniej as Turniej_DwaOgnie;
                tabelaWynikow = new TabelaWynikow(turniej.GenerujTabliceWynikow(turniej.GetListaMeczowDwaOgnie()), tmpTurniej);
                tabelaWynikow.Owner = this;
                tabelaWynikow.ShowDialog();
            }
        }

        private void Menu_zapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (tmpTurniej is Turniej_Siatkowka)
                {
                    saveFileDialog.Filter = "Turniej siatkowka (*.sia)|*.sia";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        Turniej_Siatkowka turniej = tmpTurniej as Turniej_Siatkowka;
                        turniej.ZapiszDoPliku(saveFileDialog.FileName);
                    }

                }
                if (tmpTurniej is Turniej_Lina)
                {
                    saveFileDialog.Filter = "Turniej lina (*.lin)|*.lin";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        Turniej_Lina turniej = tmpTurniej as Turniej_Lina;
                        turniej.ZapiszDoPliku(saveFileDialog.FileName);
                    }
                }

                else
                {
                    saveFileDialog.Filter = "Turniej 2 ognie (*.ogn)|*.ogn";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        Turniej_DwaOgnie turniej = tmpTurniej as Turniej_DwaOgnie;
                        turniej.ZapiszDoPliku(saveFileDialog.FileName);
                    }
                }
                    

            }
                catch
            {
                MessageBox.Show("Bład zapisu", "Bład", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}