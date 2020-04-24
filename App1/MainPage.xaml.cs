using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using InternalForcesCalculator.ViewModel;
using InternalForcesCalculator.Models;
using System.Globalization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace InternalForcesCalculator
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            // Register Syncfusion Liscense
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ2MjU4QDMxMzgyZTMxMmUzMEhMSmM5aFBRRU9yLytMZzEwWjVMZmF6eVh3TTdZbWtsQjdUTGN4VHM0eUk9");

            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

    }
}
