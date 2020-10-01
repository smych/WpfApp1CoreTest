using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfApp1CoreTest.ViewModel.Base;

namespace WpfApp1CoreTest.Model
{
    class FolderModel : ViewModelBase
    {
        private string _FileName;
        public string FileName 
        {
            get => _FileName;
            set
            {
                if (_FileName != value)
                {
                    _FileName = value;
                    RaisePropertyChanged(() => FileName);
                }
            }
        }

        private ObservableCollection<FolderModel> _ChildFolder;
        public ObservableCollection<FolderModel> ChildFolder
        {
            get => _ChildFolder;
            set 
            {
                if (_ChildFolder != value)
                {
                    _ChildFolder = value;
                    RaisePropertyChanged(() => ChildFolder);
                }
            }
        }

        private FolderModel _upFolderModel;

        public FolderModel UpFolderModel
        {
            get => _upFolderModel;
            set
            {
                if (_upFolderModel != value)
                {
                    _upFolderModel = value;
                    RaisePropertyChanged(() => UpFolderModel);
                }
            }
        }
    }
}
