using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace EdgExplorer.Shared.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Public Properties

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; }
            = new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        public ICommand AddTabItemCommand { get; }

        public ICommand CloseTabItemCommand { get; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);
            CloseTabItemCommand = new DelegateCommand(OnCloseTabItem);

            AddTabItemViewModel();
        }

        #endregion

        #region Public Methods

        public void OnClosing() { }

        #endregion

        #region Commands Methods

        private void OnAddTabItem(object obj)
        {
            AddTabItemViewModel();
        }

        private void OnCloseTabItem(object parameter)
        {
            if (parameter is DirectoryTabItemViewModel vm)
            {
                CloseTab(vm);
            }
        }

        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();

            DirectoryTabItems.Add(vm);

            CurrentDirectoryTabItem = vm;
        }

        private void CloseTab(DirectoryTabItemViewModel vm)
        {
            var isCurrent = CurrentDirectoryTabItem == vm;
            DirectoryTabItems.Remove(vm);
            if (isCurrent)
                CurrentDirectoryTabItem = DirectoryTabItems.LastOrDefault();
        }

        #endregion
    }
}