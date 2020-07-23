using System;
using System.Collections;
using System.Collections.Generic;

namespace EdgExplorer.Shared.ViewModels
{
    internal class DirectoryHistory : IDirectoryHistory
    {
        #region Private Fields

        private readonly DirectoryNode _rootDirectoryNode;

        #endregion

        #region Properties

        public bool CanMoveBack => Current.Prev != null;
        public bool CanMoveForward => Current.Next != null;

        public DirectoryNode Current { get; private set; }

        #endregion

        #region Events

        public event EventHandler HistoryChanged; 
        
        #endregion

        #region Constructor

        public DirectoryHistory(string directoryPath, string directoryName)
        {
            _rootDirectoryNode = new DirectoryNode(directoryPath, directoryName);

            Current = _rootDirectoryNode;
        }

        #endregion

        #region Public Methods

        public void MoveBack()
        {
            var prev = Current.Prev;

            Current = prev;

            RaiseHistoryChanged();
        }

        public void MoveForward()
        {
            var next = Current.Next;

            Current = next;

            RaiseHistoryChanged();
        }

        public void Add(string directoryPath, string directoryName)
        {
            var node = new DirectoryNode(directoryPath, directoryName);

            Current.Next = node;
            node.Prev = Current;

            Current = node;

            RaiseHistoryChanged();
        }

        #endregion

        #region Private Methods

        private void RaiseHistoryChanged() => HistoryChanged?.Invoke(this, EventArgs.Empty);

        #endregion

        #region Enumerator

        public IEnumerator<DirectoryNode> GetEnumerator()
        {
            yield return Current;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}