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
        public TabelaWynikow(List<Druzyna> listaDruzyn)
        {
            InitializeComponent();

            foreach(Druzyna druzyna in listaDruzyn)
            {

                TableRow row = new TableRow();
                row.Cells.Add(new TableCell(new Paragraph(new Run(druzyna.nazwa))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(druzyna.punkty.ToString()))));

                mTable.RowGroups[0].Rows.Add(row);
                
            }
        }
    }
}
