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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LoginUniversalApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pending : Page
    {
        public String x;
        public Pending()
        {
            this.InitializeComponent();
            Loaded += new RoutedEventHandler(page_loaded);
           
        }
        async void page_loaded(object sender,RoutedEventArgs e)
        {
            List<PendJson> transaction = new List<PendJson>();
            await Task.Run(() => {
                //x = File.ReadAllText(@"C:\Users\uttariya bandhu\Source\Repos\VS2015\LoginUniversalApp1\Assets\sublist.json");
                x = "[{\"name\":\"Computer Networks\",\"loc\":\"#\",\"\":null},{\"name\":\"Database Management Systems\",\"loc\":\"#\",\"\":null},{\"name\":\"Algorithms\",\"loc\":\"#\",\"\":null}]";
                JArray obj = JArray.Parse(x);
            for (int i = 0; i < obj.Count; i++)
            {

                JObject row = JObject.Parse(obj[i].ToString());
                transaction.Add(new PendJson(row["name"].ToString(), row["loc"].ToString()));

                }
            });
            listBox.ItemsSource = transaction;
        }

        private async void takeTest(object sender, TappedRoutedEventArgs e)
        {
            String sendername = ((TextBlock)sender).Text;
            String param = "";
            switch(sendername)
            {
                case "Computer Networks": param = "networktest"; break;
                case "Database Management Systems": param = "dbmstest"; break;
                case "Algorithms": param = "algotest"; break;
                default: return;
            }
            Frame.Navigate(typeof(LoginUniversalApp1.TestPage),param);
            //var dialog = new MessageDialog(((TextBlock)sender).Text);
            //await dialog.ShowAsync();
        }
    }
}
