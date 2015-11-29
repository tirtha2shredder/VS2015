using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class graded : Page
    {
        public String x;
        public graded()
        {
            this.InitializeComponent();
            Loaded += new RoutedEventHandler(page_loaded);

        }
        async void page_loaded(object sender, RoutedEventArgs e)
        {
            List<PendJson> transaction = new List<PendJson>();
            await Task.Run(() => {
                //x = File.ReadAllText(@"C:\Users\uttariya bandhu\Source\Repos\VS2015\LoginUniversalApp1\Assets\sublist.json");
                x = "[{\"name\":\"phy\",\"loc\":\"50\",\"\":null},{\"name\":\"chem\",\"loc\":\"60\",\"\":null},{\"name\":\"math\",\"loc\":\"70\",\"\":null}]";
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