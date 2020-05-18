using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using OknaDialogowe;


namespace MiniTC.ViewModel
{
    using Resx = Properties.Resources;
    class MainWindowVM : VMBase
    {
        private RelayCommand _copy;

        public VMPanelTC LeftPanelVM { get; } = new VMPanelTC();
        public VMPanelTC RightPanelVM { get; } = new VMPanelTC();

        public RelayCommand Copy
        {
            get
            {
                if (_copy == null)
                {
                    _copy = new RelayCommand(
                        action => {

                            try
                            {
                                File.Copy(LeftPanelVM.SelectedItemPath, RightPanelVM.CurrentDirectory + $"/{LeftPanelVM.SelectedItemName}");
                                RightPanelVM.RefreshList();
                            } catch
                            {
                                var dialogBox = new MessageDialogBox()
                                {
                                    Caption = Resx.FileAlreadyExistsCaption,
                                    Icon = System.Windows.MessageBoxImage.Warning,
                                    Buttons = System.Windows.MessageBoxButton.YesNo,
                                    CommandYes = new RelayCommand
                                    (
                                        arg => File.Copy(LeftPanelVM.SelectedItemPath, RightPanelVM.CurrentDirectory + $"/{LeftPanelVM.SelectedItemName}", true),
                                        arg => true
                                    ),
                                    CommandNo = null
                                };
                                dialogBox.showMessageBox(Resx.ReplaceQuestion);
                                
                            }
                        },
                        conditon => LeftPanelVM.CurrentDirectory != RightPanelVM.CurrentDirectory
                        );
                }
                return _copy;
            }
        }
        
    }
}
