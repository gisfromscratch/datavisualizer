using Earthquake.Graph.Sample.IO;
using Earthquake.Graph.Sample.Model;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Earthquake.Graph.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Read the CSV file
            var fileReader = new EarthquakeFileReader();
            var csvFile = new FileInfo(@"earthquakes.csv");
            fileReader.ReadAsync(csvFile).ContinueWith(readTask => 
            {
                // Create the data source
                var earthquakeInfos = readTask.Result;
                var earthquakeDataSource = new EnumerableDataSource<EarthquakeInfo>(earthquakeInfos);
                earthquakeDataSource.SetXMapping(earthquakeInfo => dateAxis.ConvertToDouble(earthquakeInfo.Date));
                earthquakeDataSource.SetYMapping(earthquakeInfo => earthquakeInfo.Magnitude);

                // Add the data source to the graph
                var plotterLineColor = ColorHelper.CreateRandomColors(1)[0];
                const int plotterLineWidth = 1;
                const string plotterLineLabel = @"Magnitude";
                plotter.AddLineGraph(earthquakeDataSource, plotterLineColor, plotterLineWidth, plotterLineLabel);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
