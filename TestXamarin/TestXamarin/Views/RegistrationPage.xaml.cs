using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarin;
using TestXamarin.Models;
using TestXamarin.ViewModels;
using TestXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeSurgut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        RegistrationViewModel viewModel { get; set; }
        public RegistrationPage()
        {
            BindingContext = viewModel = new RegistrationViewModel(this);
            InitializeComponent();
        }

        private void Button_Clicked_OpenLog(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}