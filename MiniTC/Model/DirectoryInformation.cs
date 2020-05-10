using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniTC.Model
{
    class DirectoryInformation
    {
        private bool _isParent;
        private bool _isDrive;

        private string _getParentDirectory()
        {
            if (_isDrive) return null;
            string directory = FullDirectory.Substring(0, FullDirectory.LastIndexOf('\\'));
            if (directory.Length == 2) directory += '\\';
            return directory;
        }


        public string FullDirectory { get; private set; }
        public string DisplayName { get => FullDirectory.Substring(FullDirectory.LastIndexOf('\\') + 1); }
        public string ParentDirectory { get => _getParentDirectory(); }
        public string Drive { get => !_isDrive? FullDirectory.Substring(0, 3) : FullDirectory; }

        public bool IsDirectory { get => File.GetAttributes(FullDirectory).HasFlag(FileAttributes.Directory); }
        public bool IsFile { get => !IsDirectory; }
        public bool IsHidden { get => !_isParent && (File.GetAttributes(FullDirectory).HasFlag(FileAttributes.Hidden) || DisplayName[0] == '.'); }

        public List<DirectoryInformation> Children { get {
                var directories = Directory.GetDirectories(FullDirectory);
                var files = Directory.GetFiles(FullDirectory);
                var list = new List<DirectoryInformation>();

                _isParent = false;
                if (ParentDirectory != null) list.Add(new DirectoryInformation(ParentDirectory, true));

                foreach (string directory in directories)
                {
                    list.Add(new DirectoryInformation(directory));
                }
                foreach (string file in files)
                {
                    list.Add(new DirectoryInformation(file));
                }
                return list;
            }
        }


        public override string ToString()
        {
            if (_isParent) return "\u21B6   ..";
            return IsDirectory? "\uD83D\uDCC1 " + DisplayName : DisplayName;
        }

        public DirectoryInformation(string path, bool asParent = false)
        {
            FullDirectory = path;
            _isParent = asParent;

            if (path.Length == 3) _isDrive = true;
            else _isDrive = false;
        }
        public DirectoryInformation()
        {
           FullDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
    }
}
