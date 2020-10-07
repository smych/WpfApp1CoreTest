using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1CoreTest.ViewModel.Base;

namespace WpfApp1CoreTest.Model
{
    class FolderModel : ViewModelBase
    {
        public string ReturnImage => @"C:\Users\sm\source\repos\WpfApp1CoreTest\WpfApp1CoreTest\Image\folder.png";

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

        // Ссылка на верхнию папку относительно текущей
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

        // Развернуто
        private bool _IsExpanded;
        public bool IsExpanded
        {
            get => _IsExpanded;
            set
            {
                if (_IsExpanded != value)
                {
                    _IsExpanded = value;
                    RaisePropertyChanged(() => IsExpanded);
                }
            }
        }

        //Для возможности выполнения запросов к главному коду
        public static WpfApp1CoreTest.ViewModel.MainViewModel GetMainView;

        public WpfApp1CoreTest.ViewModel.MainViewModel ReturnGetMain => GetMainView;

        public FolderModel GetThisFolder => this;

    }
}
