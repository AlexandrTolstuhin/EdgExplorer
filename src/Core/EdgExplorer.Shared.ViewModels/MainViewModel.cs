using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace EdgExplorer.Shared.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; }
            = new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        public ICommand AddTabItem { get; }

        public ICommand CloseTabItem { get; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddTabItem = new DelegateCommand(OnAddTabItem);
            CloseTabItem = new DelegateCommand(OnCloseTabItem);

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