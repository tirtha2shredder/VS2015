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


    
    public sealed partial class Register : Page
    {
        private bool[] changed;
        public Register()
        {
            this.InitializeComponent();
            changed = new bool[8];

        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pass_LostFocus(object sender, RoutedEventArgs e)
        {
            changed[4] = true;
            if(RePass.Password!="")
                passcheck();
        }

        private void email_LostFocus(object sender, RoutedEventArgs e)
        {
            
            changed[0] = true;
        }

        private void Fname_LostFocus(object sender, RoutedEventArgs e)
        {
            changed[1] = true;
        }

        private void Lname_LostFocus(object sender, RoutedEventArgs e)
        {
            changed[2] = true;
        }

        private void Uname_LostFocus(object sender, RoutedEventArgs e)
        {
            changed[3] = true;
        }

        private void RePass_LostFocus(object sender, RoutedEventArgs e)
        {
            changed[5] = true;
            passcheck();
         }

        private void passcheck()
        {

            if (Pass.Password.Length < 8)
            {
                Pass.BorderBrush = RePass.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                PassMsg.Text = "Password must be at least eight characters long!";
                return;
            }
            if (!(RePass.Password == Pass.Password))
                {
                    Pass.BorderBrush = RePass.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                    PassMsg.Text = "Passwords do not match!";
                }
                else
                {
                    Pass.BorderBrush = RePass.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Lime);
                    PassMsg.Text = "";
                }
        }
        private void DOB_LostFocus(object sender, RoutedEventArgs e)
        {
            changed[6] = true;
        }

        
    }
}
