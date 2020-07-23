using System.Windows;
using EdgExplorer.Shared.ViewModels;

namespace EdgExplorer.UI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Collapse_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Expand_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal 
                ? WindowState.Maximized 
                : WindowState.Normal;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel vm) vm.OnClosing();

            Application.Current.Shutdown();
        }
    }
}