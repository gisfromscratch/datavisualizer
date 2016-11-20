using ImportTextfileApp.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ImportTextfileApp.ViewModel
{
    /// <summary>
    /// Represents the import text file view model.
    /// </summary>
    public class ImportTextFileViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TextEncodingItem> _textEncodings;
        private TextEncodingItem _selectedTextEncoding;
        private ObservableCollection<CharacterSetItem> _characterSets;
        private CharacterSetItem _selectedCharacterSet;

        public ImportTextFileViewModel()
        {
            _selectedTextEncoding = new TextEncodingItem { Name = @"UTF-8" };
            _textEncodings = new ObservableCollection<TextEncodingItem>();
            _textEncodings.Add(new TextEncodingItem { Name = @"ASCII" });
            _textEncodings.Add(_selectedTextEncoding);

            _selectedCharacterSet = new CharacterSetItem { Name = @"Western" };
            _characterSets = new ObservableCollection<CharacterSetItem>();
            _characterSets.Add(_selectedCharacterSet);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TextEncodingItem> TextEncodings
        {
            get { return _textEncodings; }
            set
            {
                if (value != _textEncodings)
                {
                    _textEncodings = value;
                    OnPropertyChanged();
                }
            }
        }

        public TextEncodingItem SelectedTextEncoding
        {
            get { return _selectedTextEncoding; }
            set
            {
                if (value != _selectedTextEncoding)
                {
                    _selectedTextEncoding = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<CharacterSetItem> CharacterSets
        {
            get { return _characterSets; }
            set
            {
                if (value != _characterSets)
                {
                    _characterSets = value;
                    OnPropertyChanged();
                }
            }
        }

        public CharacterSetItem SelectedCharacterSet
        {
            get { return _selectedCharacterSet; }
            set
            {
                if (value != _selectedCharacterSet)
                {
                    _selectedCharacterSet = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = @"")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
