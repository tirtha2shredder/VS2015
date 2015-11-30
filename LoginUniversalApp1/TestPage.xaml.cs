using LoginUniversalApp1.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
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
    public sealed partial class TestPage : Page
    {
        private readonly NavigationHelper navigationHelper;

        private String testname;
        public TestPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

        }
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }
        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            //TODO: Create an appropriate data model for your problem domain to replace the sample data




            while (Frame.BackStackDepth > 1)
            {
                Frame.BackStack.RemoveAt(Frame.BackStackDepth - 1);
            }

            Test newTest = await QuestionsDataSource.GetTestAsync(testname);
            
            for (int i = 0; i < newTest.questions.Count; i++)
            {
                TestQuestion question = newTest.questions[i];
                
                StackPanel outerpanel = new StackPanel();
                outerpanel.Orientation = Orientation.Vertical;
                TextBlock quesview = new TextBlock();
                quesview.Text = question.question;
                outerpanel.Children.Add(quesview);
                if(question.type=="mcq")
                {
                    RadioButton[] radioButtons = new RadioButton[question.choices.Count];
                    int j = 0;
                    foreach(var kvp in question.choices)
                    {
                        radioButtons[j] = new RadioButton();
                        radioButtons[j].Content = kvp.Value;
                        outerpanel.Children.Add(radioButtons[j++]); 
                    }
                }
                else if(question.type == "sub")
                {
                    TextBox answer = new TextBox();
                    answer.HorizontalAlignment = HorizontalAlignment.Stretch;
                    answer.VerticalAlignment = VerticalAlignment.Stretch;
                    answer.TextWrapping = TextWrapping.Wrap;
                    outerpanel.Children.Add(answer);
                }
                
                Hub.Children.Add(outerpanel);
            }
        }
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            testname = e.Parameter.ToString();
            this.navigationHelper.OnNavigatedTo(e);

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }
    }

    public class TestQuestion
    {
        public TestQuestion(int qno, String question, String type, Dictionary<String,String> choices)
        {
            this.qno = qno;
            this.question = question;
            this.type = type;
            this.choices = choices;
        }

        public int qno { get; private set; }
        public string question { get; private set; }
        public String type { get; private set; }
        public Dictionary<String,String> choices { get; private set; }
        
    }
    public class Test
    {
        public Test(String subject, int numques, List<TestQuestion> questions)
        {
            this.subject = subject;
            this.numques = numques;
            this.questions = questions;
        }
        
        public string subject { get; private set; }
        public int numques { get; private set; }
        public List<TestQuestion> questions { get; private set; }

    }
    /// <summary>
    /// Generic group data model.
    /// </summary>


    /// <summary>
    /// Creates a collection of groups and items with content read from a static json file.
    /// 
    /// SampleDataSource initializes with data read from a static json file included in the 
    /// project.  This provides sample data at both design-time and run-time.
    /// </summary>
    public sealed class QuestionsDataSource
    {
        private static QuestionsDataSource _questionsDataSource = new QuestionsDataSource();
        

        private Test _test;
        public Test thisTest
        {
            get { return this._test; }
        }

        public static async Task<Test> GetTestAsync(String testname)
        {
            await _questionsDataSource.GetQuestionsAsync(testname);

            return _questionsDataSource.thisTest;
        }
        
        
        private async Task GetQuestionsAsync(String testname)
        {
            string jsonText="";
            try {
                Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
                
                Uri dataUri = new Uri("ms-appx:///Assets/Tests/"+testname+".json");
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                //StorageFile file = await StorageFile.GetFileFromPathAsync(installedLocation.Path + @"networktest.json");
                jsonText = await FileIO.ReadTextAsync(file);
            }
            catch(Exception e)
            {
                var dialog = new MessageDialog("ms-appx:///Assets/Tests/" + testname + ".json");
                await dialog.ShowAsync();
            }
            JsonObject jsonObject = JsonObject.Parse(jsonText);
            _test = new Test(jsonObject["test"].GetString(), int.Parse(jsonObject["numques"].GetString()), new List<TestQuestion>());
            JsonArray jsonArray = jsonObject["questions"].GetArray();
            int qno = 0;
            foreach (JsonValue item in jsonArray)
            {
                qno++;
                JsonObject questionItem = item.GetObject();
                TestQuestion question = new TestQuestion(qno,questionItem["question"].GetString(),
                                                            questionItem["type"].GetString(),
                                                            new Dictionary<string, string>());
                JsonObject choices = questionItem["choices"].GetObject();
                foreach (var choicename in choices.Keys)
                {
                    question.choices.Add(choicename,choices[choicename].GetString());
                                                       
                }

                _test.questions.Add(question);
            }
        }
    }
}
