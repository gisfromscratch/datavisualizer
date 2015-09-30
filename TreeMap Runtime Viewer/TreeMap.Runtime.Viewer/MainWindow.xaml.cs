using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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
using System.IO;
using Esri.ArcGISRuntime.Data;

namespace TreeMap.Runtime.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConcurrentQueue<DataStatisticsResult> _statisticsResults;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void WindowDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (null != filePaths)
                {
                    _statisticsResults = new ConcurrentQueue<DataStatisticsResult>();

                    var dataStatistics = new DataStatistics();
                    foreach (var filePath in filePaths)
                    {
                        if (File.Exists(filePath) && filePath.EndsWith(@".geodatabase"))
                        {
                            try
                            {
                                var geodatabase = await Geodatabase.OpenAsync(filePath);
                                var tables = geodatabase.FeatureTables;
                                foreach (var table in tables)
                                {
                                    var fields = table.Schema.Fields;
                                    foreach (var field in fields)
                                    {
                                        var result = await dataStatistics.CalculateStatistics(table, field);
                                        _statisticsResults.Enqueue(result);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                // TODO: Logging
                            }
                        }
                    }

                    treeMaps.ItemsSource = _statisticsResults;
                }
            }
        }
    }
}
