using FreeSurgut.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        ProfileViewModel viewModel;
        public ProfilePage()
        {
            BindingContext = viewModel = new ProfileViewModel();
            InitializeComponent();
            this.Appearing += ProfilePage_Appearing;
        }

        private void ProfilePage_Appearing(object sender, EventArgs e)
        {
            BindingContext = viewModel = new ProfileViewModel();
        }

        async void Setting_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}