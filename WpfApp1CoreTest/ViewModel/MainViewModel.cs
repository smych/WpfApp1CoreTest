using System.Collections.ObjectModel;
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
                            //// ###! this.CurrentFolderViewModel = ReturnFolderViewModel(SelectedItemTreeViewItem);

                            //if (this.CurrentFolder != null)
                            //    this.DirtyFlagChangedEvent -= CurrentDocument_DirtyFlagChangedEvent;

                            //if (param.NameFolder == "Root")
                            //{
                            //    this.CurrentDocument = new RootViewModel();
                            //}
                            //else


                            //this.CurrentFolderViewModel = new FolderViewModel();

                            //// Это отображение имени текущей папки
                            //this.CurrentFolderViewModel.FolderTitle = param.NameFolder;

                            //// Это коллекция файлов текущей папки
                            //this.CurrentFolderViewModel.ChildrenFileViewModelsCollection = param.ChildrenFiles;
                            // this.CancelTreeVieSelection = this.CurrentDocument.IsDirty;
                            // this.CurrentDocument.DirtyFlagChangedEvent += CurrentDocument_DirtyFlagChangedEvent;
                        }
                    });
                }

                return _selectItemChangedCommand;
            }
        }

        #endregion

        public MainViewModel()
        {
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
