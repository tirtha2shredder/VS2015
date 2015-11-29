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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginUniversalApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Tasks : Page
    {
        public Tasks()
        {
            this.InitializeComponent();
        }

        private void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginUniversalApp1.Pending));
        }

        private void OnTapped2(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginUniversalApp1.Submitted));
        }
        private void OnTapped3(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginUniversalApp1.graded));
        }
    }
}
