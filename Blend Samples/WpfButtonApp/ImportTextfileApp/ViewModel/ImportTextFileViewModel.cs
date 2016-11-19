using ImportTextfileApp.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ImportTextfileApp.ViewModel
{
    /// <summary>
    /// Represents the import text file view model.
    /// </summary>
    public class ImportTextFileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ImportTextFileViewModel()
        {
            TextEncodings = new ObservableCollection<TextEncodingItem>();
            TextEncodings.Add(new TextEncodingItem { Name = @"ASCII" });
            TextEncodings.Add(new TextEncodingItem { Name = @"UTF-8" });
        }

        public ObservableCollection<TextEncodingItem> TextEncodings { get; set; }
    }
}
