﻿using System;
using System.Collections.ObjectModel;
using System.IO;

namespace EdgExplorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : ViewModelBase
    {
        #region Private Fields

        private IDirectoryHistory _history;

        #endregion

        #region Properties

        public string FilePath { get; set; }

        public string Name { get; set; }

        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; }
            = new ObservableCollection<FileEntityViewModel>();

        public FileEntityViewModel SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public DelegateCommand Open { get; }

        public DelegateCommand MoveBack { get; }

        public DelegateCommand MoveForward { get; }

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            _history = new DirectoryHistory("My computer", "My computer");
            _history.HistoryChanged += History_OnHistoryChanged;

            Name = _history.Current.DirectoryName;
            FilePath = _history.Current.DirectoryPath;

            Open = new DelegateCommand(OnOpen);
            MoveBack = new DelegateCommand(OnMoveBack, OnCanMoveBack);
            MoveForward = new DelegateCommand(OnMoveForward, OnCanMoveForward);

            foreach (var drive in Environment.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(drive));
        }

        #endregion

        #region Commands Methods

        private void OnOpen(object parameter)
        {
            if (!(parameter is DirectoryViewModel directoryViewModel)) return;

            FilePath = directoryViewModel.FullName;
            Name = directoryViewModel.Name;

            OpenDirectory();

            _history.Add(FilePath, Name);
        }

        private void OnMoveBack(object parameter)
        {
            _history.MoveBack();

            Name = _history.Current.DirectoryName;
            FilePath = _history.Current.DirectoryPath;

            OpenDirectory();
        }

        private bool OnCanMoveBack(object parameter) => _history.CanMoveBack;

        private void OnMoveForward(object parameter)
        {
            _history.MoveForward();

            Name = _history.Current.DirectoryName;
            FilePath = _history.Current.DirectoryPath;

            OpenDirectory();
        }

        private bool OnCanMoveForward(object parameter) => _history.CanMoveForward;

        #endregion

        #region Private Methods

        private void OpenDirectory()
        {
            DirectoriesAndFiles.Clear();

            if (Name == "My computer")
            {
                foreach (var drive in Directory.GetLogicalDrives())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(drive));
            }
            else
            {
                var directoryInfo = new DirectoryInfo(FilePath);

                foreach (var directory in directoryInfo.GetDirectories())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));

                foreach (var file in directoryInfo.GetFiles())
                    DirectoriesAndFiles.Add(new FileViewModel(file));
            }
        }

        private void History_OnHistoryChanged(object sender, EventArgs e)
        {
            MoveBack?.RaiseCanExecuteChanged();
            MoveForward?.RaiseCanExecuteChanged();
        }

        #endregion
    }
}