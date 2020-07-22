using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace EdgExplorer.Shared.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Private Fields

        private string _filePath;
        private FileEntityViewModel _selectedFileEntity;

        #endregion

        #region Public Properties

        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
            = new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity
        {
            get => _selectedFileEntity;
            set
            {
                _selectedFileEntity = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand OpenCommand { get; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            OpenCommand = new DelegateCommand(Open);

            foreach (var drive in Environment.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(drive));
        }

        #endregion

        #region Commands Methods

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;

                DirectoriesAndFiles.Clear();

                var directoryInfo = new DirectoryInfo(FilePath);

                foreach (var directory in directoryInfo.GetDirectories())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));

                foreach (var file in directoryInfo.GetFiles()) DirectoriesAndFiles.Add(new FileViewModel(file));
            }
        }

        #endregion
    }
}