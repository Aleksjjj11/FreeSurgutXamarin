using Android.OS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Input;
using Android.Content.Res;
using FreeSurgut.Views;
using TestXamarin.Models;
using TestXamarin.ViewModels;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private LoginPage _page;
        //private IMyRestClient _restClient;
        private string _username;
        public string Username 
        {
            get => _username; 
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            } 
        }

        private string _password;
        public string Password { 
            get => _password; 
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _accessToken;

        private bool _hidePassword;
        public bool HidePassword 
        { 
            get => _hidePassword;
            set
            {
                _hidePassword = value;
                OnPropertyChanged(nameof(HidePassword));
            } 
        }

        private ICommand _goToRegistration;

        public ICommand GoToRegistration => _goToRegistration ?? new Command(() =>
        {
            _page.Navigation.PopModalAsync();

        }, () => true);
        private ICommand _authorizeCommand;

        public ICommand AuthorizeCommand => _authorizeCommand ?? new Command(() =>
        {
            var user = Authorize();
            if (user is null)
            {
                _page.DisplayAlert("Ошибка", "Произогла ошибка во время авторизации.\nПопробуйте проверить логин и пароль.", "Ok");
                return;
            }
            (App.Current as App).TheUser = user;
            _page.Navigation.PopModalAsync();
        }, () => Username != "" && Password != "");

        public LoginViewModel(LoginPage page)
        {
            _page = page;
            Title = "Авторизация";
            HidePassword = true;
        }
        public User Authorize()
        {
            try
            {
                var client = new RestClient("http://188.225.83.42:8080/login/");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("name", Username);
                request.AddParameter("password", Password);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                    return null;
                var jObject = JObject.Load(new JsonTextReader(new StringReader(response.Content)));
                return new User
                {
                    RealName = jObject["real_name"]?.ToString(),
                    UserName = jObject["name"]?.ToString(),
                    Email = jObject["email"]?.ToString(),
                    Password = this.Password,
                    Reports = new ObservableCollection<Report>(),
                    Achievements = new ObservableCollection<Achievement>()
                };
            }
            catch (Exception exp)
            {
                return null;
            }
        }
    }
}
