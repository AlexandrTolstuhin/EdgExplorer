using System;

namespace EdgExplorer.Shared.ViewModels
{
    public class MainViewModel : ViewModelBase
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

        public MainViewModel()
        {
            MainDiskName = Environment.SystemDirectory;
        }
    }
}