namespace EdgExplorer.Shared.ViewModels
{
    internal class DirectoryNode
    {
        public DirectoryNode Prev { get; set; }
        public DirectoryNode Next { get; set; }

        public string DirectoryPath { get; }
        public string DirectoryName { get; }

        public DirectoryNode(string directoryPath, string directoryName)
            => (DirectoryPath, DirectoryName) = (directoryPath, directoryName);
    }
}