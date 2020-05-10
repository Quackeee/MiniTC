﻿using System;
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

namespace MiniTC
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {

        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(
            "SelectedItem",
            typeof(string),
            typeof(PanelTC),
            new PropertyMetadata(String.Empty));

        public string SelectedItem
        {
            get { return (string) GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public PanelTC()
        {
            InitializeComponent();
        }
    }
}