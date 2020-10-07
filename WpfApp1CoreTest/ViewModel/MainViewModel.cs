using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using WpfApp1CoreTest.Model;
using WpfApp1CoreTest.ViewModel.Base;

namespace WpfApp1CoreTest.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<FolderModel> _getFolderCollection = null;
        public ObservableCollection<FolderModel> GetFolderCollection
        {
            get => _getFolderCollection;
            set
            {
                if (_getFolderCollection != value)
                {
                    _getFolderCollection = value;
                    RaisePropertyChanged(() => GetFolderCollection);
                }
            }
        }

        private FolderModel _curentFolder;
        public FolderModel GetCurentFolder
        {
            get => _curentFolder;
            set
            {
                if (_curentFolder != value)
                {
                    _curentFolder = value;

                    RaisePropertyChanged(() => GetCurentFolder);

                    // Создаем новый список ListBox
                    GetFolderUpCollection = ListFolders.ListFolderReturn(_curentFolder);
                }
            }
        }

        /// <summary>
        /// Список ListBox
        /// </summary>
        //private ObservableCollection<FolderModel> _getFolderUpCollection = null;
        //public ObservableCollection<FolderModel> GetFolderUpCollection
        //{
        //    get => _getFolderUpCollection;
        //    set
        //    {
        //        if (_getFolderUpCollection != value)
        //        {
        //            _getFolderUpCollection = value;
        //            RaisePropertyChanged(() => GetFolderUpCollection);
        //        }
        //    }
        //}
        private List<FolderModel> _getFolderUpCollection = null;
        public List<FolderModel> GetFolderUpCollection
        {
            get => _getFolderUpCollection;
            set
            {
                if (_getFolderUpCollection != value)
                {
                    _getFolderUpCollection = value;
                    RaisePropertyChanged(() => GetFolderUpCollection);
                }
            }
        }


        // Необходим для алгоритма создания начало точки поиска
        private FolderModel RootFolder;

        private ICommand _selectItemChangedCommand = null;
        /// <summary>
        /// Gets a command that changes the currently selected item in the tree of items.
        /// The command expects a <seealso cref="ItemTreeViewModel"/> object as parameter.
        /// </summary>
        public ICommand SelectItemChangedCommand
        {
            get
            {
                if (_selectItemChangedCommand == null)
                {
                    _selectItemChangedCommand = new RelayCommand<object>((p) =>
                    {
                        FolderModel param = p as FolderModel;

                        if (param != null)
                        {
                            this.GetCurentFolder = param;
                        }
                    });
                }

                return _selectItemChangedCommand;
            }
        }

        //
        // На одну папку выше
        private ICommand _upFolderCommand = null;
        public ICommand UpFolderCommand
        {
            get
            {
                if (_upFolderCommand == null)
                {
                    _upFolderCommand = new RelayCommand<object>((p) =>
                    {
                        FolderModel itemFolder = p as FolderModel;
                        if (itemFolder != null)
                        {
                            GetCurentFolder = itemFolder;
                        }
                    }
                    );
                }

                return _upFolderCommand;
            }
        }


        #endregion

        public MainViewModel()
        {
            FolderModel.GetMainView = this;
            GetFolderCollection = CreateCollection();
        }


        // Создание коллекции
        ObservableCollection<FolderModel> CreateCollection()
        {
            #region CreateCollection folderCollection

            var temp = new ObservableCollection<FolderModel>
            {
               new FolderModel
               { FileName = "Folder-1", ChildFolder = new ObservableCollection<FolderModel>
                   {new FolderModel
                       { FileName = "Folder-1.1", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-1.1.1", ChildFolder = new ObservableCollection<FolderModel>
                                     {
                                        new FolderModel
                                        {FileName = "Folder-1.1.1.1", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel
                                                {FileName = "Folder-1.1.1.1.1", ChildFolder = new ObservableCollection<FolderModel>
                                                    {
                                                        new FolderModel{FileName = "Folder-1.1.1.1.1.1", ChildFolder = null },
                                                        new FolderModel{FileName = "Folder-1.1.1.1.1.2", ChildFolder = null }
                                                    }
                                                },
                                                new FolderModel
                                                {FileName = "Folder-1.1.1.1.2", ChildFolder = new ObservableCollection<FolderModel>
                                                    {
                                                        new FolderModel{FileName = "Folder-1.1.1.1.2.1", ChildFolder = null },
                                                        new FolderModel{FileName = "Folder-1.1.1.1.2.2", ChildFolder = null }
                                                    }
                                                }
                                            }
                                        },
                                        new FolderModel
                                        {FileName = "Folder-1.1.1.2", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{FileName = "Folder-1.1.1.2.1", ChildFolder = null },
                                                new FolderModel{FileName = "Folder-1.1.1.2.2", ChildFolder = null },
                                                new FolderModel{FileName = "Folder-1.1.1.2.3", ChildFolder = null }
                                            }
                                        }
                                     }
                                 },
                                 new FolderModel{ FileName = "Folder-1.1.2", ChildFolder  = new ObservableCollection<FolderModel>
                                     {
                                        new FolderModel{FileName = "Folder-1.1.2.1", ChildFolder = null },
                                        new FolderModel{FileName = "Folder-1.1.2.2", ChildFolder = null }
                                     }
                                 },
                                 new FolderModel{ FileName = "Folder-1.1.3", ChildFolder = new ObservableCollection<FolderModel>
                                     {
                                        new FolderModel{FileName = "Folder-1.1.3.1", ChildFolder = null },
                                        new FolderModel{FileName = "Folder-1.1.3.2", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{FileName = "Folder-1.1.3.2.1", ChildFolder = null },
                                                new FolderModel{FileName = "Folder-1.1.3.2.2", ChildFolder = null }
                                            }
                                        }
                                     }
                                 },
                            }
                       },
                       new FolderModel
                       { FileName = "Folder-1.2", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-1.2.1", ChildFolder = null },
                                 new FolderModel{ FileName = "Folder-1.2.1", ChildFolder = null }
                            }
                       }
                   }


               },
               new FolderModel
               { FileName = "Folder-2",
                   ChildFolder = new ObservableCollection<FolderModel>
                   {
                       new FolderModel
                       { FileName = "Folder-2.1", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{
                                     FileName = "Folder-2.1.1", ChildFolder = new ObservableCollection<FolderModel>
                                     {
                                        new FolderModel{FileName = "Folder-2.1.1.1", ChildFolder = null },
                                        new FolderModel{FileName = "Folder-2.1.1.2", ChildFolder = null },
                                        new FolderModel{FileName = "Folder-2.1.1.3", ChildFolder = null },
                                     }
                                 },
                                 new FolderModel{
                                     FileName = "Folder-2.1.2", ChildFolder = new ObservableCollection<FolderModel>
                                     {
                                        new FolderModel{FileName = "Folder-2.1.2.1", ChildFolder = null },
                                        new FolderModel{FileName = "Folder-2.1.2.2", ChildFolder = null }
                                     }
                                 },
                                 new FolderModel{
                                     FileName = "Folder-2.1.3", ChildFolder = new ObservableCollection<FolderModel>
                                     {
                                        new FolderModel{
                                            FileName = "Folder-2.1.3.1", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{FileName = "Folder-2.1.3.1.1", ChildFolder = null },
                                                new FolderModel{FileName = "Folder-2.1.3.1.2", ChildFolder = null }
                                            }
                                        },
                                        new FolderModel{
                                            FileName = "Folder-2.1.3.2", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{FileName = "Folder-2.1.3.2.1", ChildFolder = null },
                                                new FolderModel{FileName = "Folder-2.1.3.2.2", ChildFolder = null }
                                            }
                                        }
                                     }
                                 }
                            }
                       },
                       new FolderModel
                       { FileName = "Folder-2.2", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-2.2.1", ChildFolder = new ObservableCollection<FolderModel>
                                        {
                                            new FolderModel{ FileName = "Folder-2.2.1.1", ChildFolder = null },
                                            new FolderModel{ FileName = "Folder-2.2.1.2", ChildFolder = null }
                                        }
                                 },
                                 new FolderModel{ FileName = "Folder-2.2.2", ChildFolder = new ObservableCollection<FolderModel>
                                        {
                                            new FolderModel{ FileName = "Folder-2.2.2.1", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.2.2.1.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.2.2.1.2", ChildFolder = null }
                                                }
                                            },
                                            new FolderModel{ FileName = "Folder-2.2.2.2", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.2.2.2.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.2.2.2.2", ChildFolder = null }
                                                }
                                            }
                                        }
                                 },
                                 new FolderModel{ FileName = "Folder-2.2.3", ChildFolder = new ObservableCollection<FolderModel>
                                        {
                                            new FolderModel{ FileName = "Folder-2.2.3.1", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.2.3.1.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.2.3.1.2", ChildFolder = null }
                                                }
                                            },
                                            new FolderModel{ FileName = "Folder-2.2.3.2", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.2.3.2.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.2.3.2.2", ChildFolder = null }
                                                }
                                            }
                                        }
                                 }
                            }
                       },
                       new FolderModel
                       { FileName = "Folder-2.3", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-2.3.1", ChildFolder = new ObservableCollection<FolderModel>
                                        {
                                            new FolderModel{ FileName = "Folder-2.3.1.1", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.3.1.1.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.3.1.1.2", ChildFolder = null }
                                                }
                                            },
                                            new FolderModel{ FileName = "Folder-2.3.1.2", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.3.1.2.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.3.1.2.2", ChildFolder = null }
                                                }
                                            }
                                        }
                                 },
                                 new FolderModel{ FileName = "Folder-2.3.2", ChildFolder = new ObservableCollection<FolderModel>
                                        {
                                            new FolderModel{ FileName = "Folder-2.3.2.1", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.3.2.1.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.3.2.1.2", ChildFolder = null }
                                                }
                                            },
                                            new FolderModel{ FileName = "Folder-2.3.2.2", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.3.2.2.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.3.2.2.2", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.3.2.2.3", ChildFolder = null }
                                                }
                                            }
                                        }
                                 },
                                 new FolderModel{ FileName = "Folder-2.3.3", ChildFolder = new ObservableCollection<FolderModel>
                                        {
                                            new FolderModel{ FileName = "Folder-2.3.3.1", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.3.3.1.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.3.3.1.2", ChildFolder = null }
                                                }
                                            },
                                            new FolderModel{ FileName = "Folder-2.3.3.2", ChildFolder = new ObservableCollection<FolderModel>
                                                {
                                                    new FolderModel{ FileName = "Folder-2.3.3.2.1", ChildFolder = null },
                                                    new FolderModel{ FileName = "Folder-2.3.3.2.2", ChildFolder = null }
                                                }
                                            }
                                        }
                                 }
                            }
                       }
                   }


               },

               new FolderModel
               { FileName = "Folder-3",
                   ChildFolder = new ObservableCollection<FolderModel>
                   {
                       new FolderModel
                       { FileName = "Folder-3.1", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-3.1.1", ChildFolder = new ObservableCollection<FolderModel>
                                    {
                                        new FolderModel{ FileName = "Folder-3.1.1.1", ChildFolder = null },
                                        new FolderModel{ FileName = "Folder-3.1.1.2", ChildFolder = null }
                                    }
                                 },
                                 new FolderModel{ FileName = "Folder-3.1.2", ChildFolder = new ObservableCollection<FolderModel>
                                    {
                                        new FolderModel{ FileName = "Folder-3.1.2.1", ChildFolder = null },
                                        new FolderModel{ FileName = "Folder-3.1.2.2", ChildFolder = null },
                                        new FolderModel{ FileName = "Folder-3.1.2.3", ChildFolder = null }
                                    }
                                 }
                            }
                       },
                       new FolderModel
                       { FileName = "Folder-3.2", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-3.2.1", ChildFolder = new ObservableCollection<FolderModel>
                                    {
                                        new FolderModel{ FileName = "Folder-3.2.1.1", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{ FileName = "Folder-3.2.1.1.1", ChildFolder = null },
                                                new FolderModel{ FileName = "Folder-3.2.1.1.2", ChildFolder = null }
                                            }
                                        },
                                        new FolderModel{ FileName = "Folder-3.2.2", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{ FileName = "Folder-3.1.2.1", ChildFolder = null },
                                                new FolderModel{ FileName = "Folder-3.1.2.2", ChildFolder = null }
                                            }
                                        }
                                    }
                                 },
                                 new FolderModel{ FileName = "Folder-3.2.2", ChildFolder = new ObservableCollection<FolderModel>
                                    {
                                        new FolderModel{ FileName = "Folder-3.2.2.1", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{ FileName = "Folder-3.2.2.1.1", ChildFolder = null },
                                                new FolderModel{ FileName = "Folder-3.2.2.1.2", ChildFolder = null }
                                            }
                                        },
                                        new FolderModel{ FileName = "Folder-3.2.2.2", ChildFolder = new ObservableCollection<FolderModel>
                                            {
                                                new FolderModel{ FileName = "Folder-3.2.2.2.1", ChildFolder = null },
                                                new FolderModel{ FileName = "Folder-3.2.2.2.2", ChildFolder = null }
                                            }
                                        }
                                    }
                                 }

                            }
                       }
                   }
               },

               new FolderModel
               { FileName = "Folder-4",
                   ChildFolder = new ObservableCollection<FolderModel>
                   {
                       new FolderModel
                       { FileName = "Folder-4.1", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-4.1.1", ChildFolder = null },
                                 new FolderModel{ FileName = "Folder-4.1.2", ChildFolder = null },
                                 new FolderModel{ FileName = "Folder-4.1.3", ChildFolder = null },
                                 new FolderModel{ FileName = "Folder-4.1.4", ChildFolder = null }
                            }
                       },
                       new FolderModel
                       { FileName = "Folder-4.2", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-4.2.1", ChildFolder = null },
                                 new FolderModel{ FileName = "Folder-4.2.2", ChildFolder = null }
                            }
                       },
                       new FolderModel
                       { FileName = "Folder-4.3", ChildFolder = new ObservableCollection<FolderModel>
                            {
                                 new FolderModel{ FileName = "Folder-4.3.1", ChildFolder = null },
                                 new FolderModel{ FileName = "Folder-4.3.2", ChildFolder = null },
                                 new FolderModel{ FileName = "Folder-4.3.3", ChildFolder = null }
                            }
                       }
                   }
               }

            };
            #endregion

            RootFolder = new FolderModel { FileName = "RootFolder", ChildFolder = temp, UpFolderModel = null };

            var RootFolderCollection = new ObservableCollection<FolderModel> { RootFolder };

            returnFM(RootFolderCollection, RootFolder);


            void returnFM(ObservableCollection<FolderModel> _tempCollection, FolderModel _tempFolder)
            {
                if (_tempCollection != null)
                {
                    foreach (var item in _tempCollection)
                    {
                        if (item != RootFolder)
                        {
                            item.UpFolderModel = _tempFolder;
                        }

                        returnFM(item.ChildFolder, item);
                    }
                }
            }

            return temp;
        }

    }
}
