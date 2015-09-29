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

            var tableItem = new TableItem();

            var idValues = new List<AttributeValue>();
            idValues.Add(new AttributeValue { Value = @"TT", Count = 1 });
            idValues.Add(new AttributeValue { Value = @"SS", Count = 10 });

            var attributes = new List<TreeMap.Runtime.Viewer.Model.Attribute>();
            attributes.Add(new TreeMap.Runtime.Viewer.Model.Attribute { Name = @"ID", AttributeValues = idValues });

            var nameValues = new List<AttributeValue>();
            nameValues.Add(new AttributeValue { Value = @"TT", Count = 11 });
            attributes.Add(new TreeMap.Runtime.Viewer.Model.Attribute { Name = @"Name", AttributeValues = nameValues });

            tableItem.Attributes = attributes;
            treeMaps.ItemsSource = tableItem.Attributes;
        }
    }
}
