﻿using MiniTC.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MiniTC.ViewModel
{

    internal class VMPanelTC : VMBase
    {
        private bool _showHidden = false;
        private string _selectedDrive = null;
        private DirectoryInformation _currentDirectory = new DirectoryInformation();
        private int _selectedIndex;
        private string _selectedItemPath;


        public static string[] Drives { get; } = Directory.GetLogicalDrives();
        public string CurrentDirectory { get => _currentDirectory.FullDirectory; }
        public string SelectedDrive { get { if (_selectedDrive == null) _selectedDrive = _currentDirectory.Drive; return _selectedDrive; } set => _selectedDrive = value; }
        public List<DirectoryInformation> DirectoryContent { get { if (ShowHidden) return _currentDirectory.Children;
                else { var children = _currentDirectory.Children;
                    for (int i = 0; i < children.Count; i++) if (children[i].IsHidden) { children.RemoveAt(i); i--; };
                    return children;
                }
            }
        }
        
        public int SelectedIndex { get => _selectedIndex;
            set
            {
                _selectedIndex = value; Debug.WriteLine(_selectedIndex);
                if (SelectedIndex != -1) SelectedItemPath = DirectoryContent[SelectedIndex].FullDirectory;
                else SelectedItemPath = null;
            }
        }
        public bool ShowHidden
        {
            get => _showHidden;
            set { _showHidden = value; OnPropertyChanged(nameof(DirectoryContent));}
        }

        private RelayCommand _changeDirectory = null;
        private RelayCommand _changeDrive = null;

        public RelayCommand ChangeDirectory { get
            {
                if (_changeDirectory == null)
                    _changeDirectory = new RelayCommand(
                        arg =>
                        {
                            _currentDirectory = DirectoryContent[SelectedIndex];
                            OnPropertyChanged(nameof(CurrentDirectory), nameof(SelectedDrive), nameof(DirectoryContent));
                        },
                        arg => SelectedIndex != -1 && DirectoryContent[SelectedIndex].IsDirectory );
                return _changeDirectory;
            }
        }
        public RelayCommand ChangeDrive
        {
            get
            {
                if (_changeDrive == null)
                    _changeDrive = new RelayCommand(
                        arg =>
                        {
                            _currentDirectory = new DirectoryInformation(SelectedDrive);
                            OnPropertyChanged(nameof(CurrentDirectory), nameof(DirectoryContent));
                        },
                        arg => true );

                return _changeDrive;
            }
        }

        public string SelectedItemPath { get => _selectedItemPath; set { _selectedItemPath = value; Debug.WriteLine(SelectedItemPath); OnPropertyChanged(nameof(SelectedItemPath)); } }
        public string SelectedItemName { get => DirectoryContent[SelectedIndex].Name; }

        public void RefreshList() => OnPropertyChanged(nameof(DirectoryContent));
    }
}
