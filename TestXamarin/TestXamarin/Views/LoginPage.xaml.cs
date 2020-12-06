using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestXamarin;
using TestXamarin.ViewModels;
using TestXamarin.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeSurgut.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            BindingContext = viewModel = new LoginViewModel(this);
            InitializeComponent();
        }

        private void CheckBox_ShowPass_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Entry_Pass.IsPassword = viewModel.HidePassword;
        }

        private void Button_Clicked_OpenReg(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new RegistrationPage());
        }
    }
}