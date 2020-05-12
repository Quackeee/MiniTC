using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace MiniTC.ViewModel
{
    class MainWindowVM : VMBase
    {

        private VMPanelTC _leftPanelVM;
        private VMPanelTC _rightPanelVM;
        private RelayCommand _copy;

        public VMPanelTC LeftPanelVM
        {
            get
            {
                if (_leftPanelVM == null)
                {
                    _leftPanelVM = new VMPanelTC();
                }
                return _leftPanelVM;
            }
        }
        public VMPanelTC RightPanelVM
        {
            get
            {
                if (_rightPanelVM == null)
                {
                    _rightPanelVM = new VMPanelTC();
                }
                return _rightPanelVM;
            }
        }

        public RelayCommand Copy
        {
            get
            {
                if (_copy == null)
                {
                    _copy = new RelayCommand(
                        action => { File.Copy(LeftPanelVM.SelectedItemPath, RightPanelVM.CurrentDirectory + $"/{LeftPanelVM.SelectedItemName}");
                            RightPanelVM.RefreshList();
                        },
                        conditon => LeftPanelVM.CurrentDirectory != RightPanelVM.CurrentDirectory
                        );
                }
                return _copy;
            }
        }
    
    }
}
