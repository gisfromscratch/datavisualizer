using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfTableApp.ViewModel
{
    internal class TableViewModel : INotifyPropertyChanged
    {
        private DataView _tableView;

        internal TableViewModel()
        {
            LoadCommand = new LoadCommand(this);
            var dataTable = new DataTable();
            TableView = dataTable.AsDataView();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoadCommand { get; private set; }

        public DataView TableView
        {
            get { return _tableView; }
            set
            {
                _tableView = value;
                RaisPropertyChanged();
            }
        }

        private void RaisPropertyChanged([CallerMemberName] string propertyName = @"")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// The load file command.
    /// </summary>
    class LoadCommand : ICommand
    {
        private readonly TableViewModel _viewModel;

        internal LoadCommand(TableViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var path = parameter as string;
            return (null != path && File.Exists(path));
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            // Read the file
            var dataTable = new DataTable();
            var path = parameter as string;
            const char tokenDelimiter = ',';
            var columnNames = new HashSet<string>();
            using (var streamReader = new StreamReader(path))
            {
                string line;
                while (null != (line = streamReader.ReadLine()))
                {
                    var tokens = line.Split(tokenDelimiter);
                    if (dataTable.Columns.Count < 1)
                    {
                        foreach (var token in tokens)
                        {
                            // Ensure the column name is unique
                            var columnName = token;
                            for (var counter = 2; columnNames.Contains(columnName); counter++)
                            {
                                columnName = string.Format(@"{0}{1}", token, counter);
                            }
                            dataTable.Columns.Add(columnName);
                            columnNames.Add(columnName);
                        }
                    }
                    else
                    {
                        dataTable.Rows.Add(tokens);
                    }
                }
            }

            // Update the view model
            _viewModel.TableView = dataTable.AsDataView();
        }
    }
}
