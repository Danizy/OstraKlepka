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
    /// Interaction logic for TabelaWynikow.xaml
    /// </summary>
    public partial class TabelaWynikow : Window
    {
        public TabelaWynikow(List<Druzyna> listaDruzyn, Turniej turniej)
        {
            InitializeComponent();

            if(turniej.wynikiGrup == null)
            {
                utworzFaze(listaDruzyn, "Faza Grupowa");
            }

            else if(turniej.wynikiPolfinal == null)
            {
                utworzFaze(listaDruzyn, "Faza polfinalowa");
                utworzFaze(turniej.wynikiGrup, "Faza Grupowa");
            }

            else if(turniej.wynikiFinal == null)
            {
                utworzFaze(listaDruzyn, "Faza finałowa");
                utworzFaze(turniej.wynikiPolfinal, "Faza polfinalowa");
                utworzFaze(turniej.wynikiGrup, "Faza Grupowa");
            }

            else if(turniej.wynikiFinal != null)
            {
                utworzFaze(turniej.wynikiFinal, "Faza finałowa");
                utworzFaze(turniej.wynikiPolfinal, "Faza polfinalowa");
                utworzFaze(turniej.wynikiGrup, "Faza Grupowa");
            }

            
        }

        private void wypiszDruzyny(List<Druzyna> druzyny)
        {
            foreach (Druzyna druzyna in druzyny)
            {

                TableRow row = new TableRow();
                TableCell cell = new TableCell(new Paragraph(new Run(druzyna.nazwa)));
                cell.BorderBrush = Brushes.Black;
                cell.BorderThickness = new Thickness(0, 1, 1, 0);
                cell.TextAlignment = TextAlignment.Center;
                row.Cells.Add(cell);

                cell = new TableCell(new Paragraph(new Run(druzyna.punkty.ToString())));
                cell.BorderBrush = Brushes.Black;
                cell.BorderThickness = new Thickness(0, 1, 1, 0);
                cell.TextAlignment = TextAlignment.Center;
                row.Cells.Add(cell);

                mTable.RowGroups[0].Rows.Add(row);

            }
        }

        private void utworzFaze(List<Druzyna> druzyny, string faza)
        {
            TableRow header = new TableRow();
            TableCell headerCell = new TableCell(new Paragraph(new Run(faza)));
            headerCell.ColumnSpan = 2;
            headerCell.Background = Brushes.LightSlateGray;
            headerCell.FontSize = 20;
            headerCell.TextAlignment = TextAlignment.Center;
            header.Cells.Add(headerCell);
            mTable.RowGroups[0].Rows.Add(header);

            wypiszDruzyny(druzyny);
        }
    }
}
