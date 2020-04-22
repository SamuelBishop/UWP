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
        // private DispatcherTimer timer;
        // private int counter = 0;

        public MainPage()
        {
            this.InitializeComponent();
            // timer = new DispatcherTimer();

            // Loaded += MainPage_Loaded;

            // new ShearForce { XCoord = float.Parse(PointLoadingLocation.Text, CultureInfo.InvariantCulture.NumberFormat), YCoord = float.Parse(PointLoadingMagnitude.Text, CultureInfo.InvariantCulture.NumberFormat) }; 
        }

        //private void MainPage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    timer.Interval = TimeSpan.FromSeconds(1.0);
        //    timer.Tick += Timer_Tick;
        //    timer.Start();
        //}

        //private void Timer_Tick(object sender, object e)
        //{
        //    if (counter == 5)
        //    {
        //        //do operation in every 5 seconds
        //        counter = 0;
        //        //if you want to stop the timer use timer.Start()
        //    }
        //    else
        //    {
        //        counter++;
        //    }
        //}

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

    }
}
