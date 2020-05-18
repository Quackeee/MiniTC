using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OknaDialogowe
{
    public class OpenFileDialogBox : FileDialogBox
    {
        public OpenFileDialogBox()
        {
            fileDialog = new Microsoft.Win32.OpenFileDialog();
        }
    }
}
