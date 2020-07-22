using System.IO;

namespace EdgExplorer.Shared.ViewModels
{
    public sealed class FileViewModel : FileEntityViewModel
    {
        public FileViewModel(string fileName)
            : base(fileName, fileName)
        { }

        public FileViewModel(FileInfo fileInfo)
            : base(fileInfo.Name, fileInfo.FullName)
        { }
    }
}