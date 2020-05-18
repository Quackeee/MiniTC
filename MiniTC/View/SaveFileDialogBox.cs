using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OknaDialogowe
{
    public class SaveFileDialogBox : FileDialogBox
    {
        public SaveFileDialogBox()
        {
            fileDialog = new Microsoft.Win32.SaveFileDialog();
        }
    }
}
