using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace EdgExplorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : ViewModelBase
    {
        #region Public Properties

        public string FilePath { get; set; }

        public string Name { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
            = new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public ICommand OpenCommand { get; }

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            Name = "My Computer";

            OpenCommand = new DelegateCommand(Open);

            foreach (var drive in Environment.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(drive));
        }

        #endregion

        #region Commands Methods

        private void Open(object parameter)
        {
            if (!(parameter is DirectoryViewModel directoryViewModel)) return;

            FilePath = directoryViewModel.FullName;
            Name = directoryViewModel.Name;

            DirectoriesAndFiles.Clear();

            var directoryInfo = new DirectoryInfo(FilePath);

            foreach (var directory in directoryInfo.GetDirectories())
                DirectoriesAndFiles.Add(new DirectoryViewModel(directory));

            foreach (var file in directoryInfo.GetFiles()) 
                DirectoriesAndFiles.Add(new FileViewModel(file));
        }

        #endregion
    }
}