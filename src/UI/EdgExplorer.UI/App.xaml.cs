using System.Windows;

namespace EdgExplorer.UI
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
            {
                DataContext = new MainViewModel { MainDiskName = "C:\\"}
            };
            window.Show();
        }
    }
}