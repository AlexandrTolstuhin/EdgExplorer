using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EdgExplorer.UI
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _mainDiskName;

        public string MainDiskName
        {
            get => _mainDiskName;
            set
            {
                _mainDiskName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}