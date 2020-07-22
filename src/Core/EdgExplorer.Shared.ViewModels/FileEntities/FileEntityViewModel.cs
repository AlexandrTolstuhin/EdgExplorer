namespace EdgExplorer.Shared.ViewModels
{
    public abstract class FileEntityViewModel : ViewModelBase
    {
        public string Name { get; }
        public string FullName { get; }

        protected FileEntityViewModel(string name, string fullName)
            => (Name, FullName) = (name, fullName);
    }
}