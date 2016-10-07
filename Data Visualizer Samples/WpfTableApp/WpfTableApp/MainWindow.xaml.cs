using System.Windows;
using WpfTableApp.ViewModel;

namespace WpfTableApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create the view model
            DataContext = new TableViewModel();
        }

        private void DataGrid_Drop(object sender, DragEventArgs e)
        {
            var viewModel = DataContext as TableViewModel;
            if (null == viewModel || !e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            var filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (null == filePaths || 1 != filePaths.Length)
            {
                return;
            }

            if (viewModel.LoadCommand.CanExecute(filePaths[0]))
            {
                viewModel.LoadCommand.Execute(filePaths[0]);
            }
        }
    }
}
