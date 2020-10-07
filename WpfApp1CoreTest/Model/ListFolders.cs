using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WpfApp1CoreTest.ViewModel.Base;

namespace WpfApp1CoreTest.Model
{
    static class ListFolders
    {

        //FolderModel temp { get; set; }

        public static List<FolderModel> ListFolderReturn(FolderModel _folder)
        {
            if (_folder == null)
            {
                return null;
            }

            // List<int> a = new List<int>();
            List<FolderModel> _temp = new List<FolderModel>();

            do
            {

                _temp.Add(_folder);
                _folder = _folder.UpFolderModel;

            }
            while (_folder != null);

            _temp.Reverse();

            return _temp;
        }
    }
}
