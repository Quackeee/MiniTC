using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace MiniTC
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {

        public static DependencyProperty SelectedItemPathProperty =
        DependencyProperty.Register(
            "SelectedItemPath",
            typeof(string),
            typeof(PanelTC),
            new PropertyMetadata(String.Empty, OnSelectedItemPathChanged));

        public string SelectedItemPath
        {
            get { Debug.WriteLine("SelectedItemPath requested"); return (string) GetValue(SelectedItemPathProperty); }
            set { SetValue(SelectedItemPathProperty, value); }
        }

        private static void OnSelectedItemPathChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("SelectedItemPath changed");
        }

        public PanelTC()
        {
            InitializeComponent();

            var binding = new Binding("SelectedItemPath") { Mode = BindingMode.OneWay };
            SetBinding(SelectedItemPathProperty, binding);
        }
    }
}
