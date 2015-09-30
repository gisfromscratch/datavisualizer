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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeMap.Runtime.Viewer.Model;

namespace TreeMap.Runtime.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var statisticsResults = new List<DataStatisticsResult>();
            statisticsResults.Add(new DataStatisticsResult { Name = @"OID", Count = 100 });
            statisticsResults.Add(new DataStatisticsResult { Name = @"SHAPE", Count = 1 });
            statisticsResults.Add(new DataStatisticsResult { Name = @"SHAPE", Count = 1 });

            var tableItem = new TableItem { TableName = @"Points", RowCount = 100, StatisticsResults = statisticsResults };

            var tableItems = new List<TableItem>();
            tableItems.Add(tableItem);
            treeMaps.ItemsSource = statisticsResults;
        }
    }
}
