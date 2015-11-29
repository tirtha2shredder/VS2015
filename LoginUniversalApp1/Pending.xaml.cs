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
                x = "[{\"name\":\"phy\",\"loc\":\"#\",\"\":null},{\"name\":\"chem\",\"loc\":\"#\",\"\":null},{\"name\":\"math\",\"loc\":\"#\",\"\":null}]";
                JArray obj = JArray.Parse(x);
            for (int i = 0; i < obj.Count; i++)
            {

                JObject row = JObject.Parse(obj[i].ToString());
                transaction.Add(new PendJson(row["name"].ToString(), row["loc"].ToString()));

                }
            });
            listBox.ItemsSource = transaction;
        }
     
    }
}
