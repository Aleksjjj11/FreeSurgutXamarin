using FreeSurgut.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace TestXamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            //if ((App.Current as App).TheUser.UserName == "" || (App.Current as App).TheUser.Email == "" || (App.Current as App).TheUser.Password == "")
            //{
            //}
        }
    }
}