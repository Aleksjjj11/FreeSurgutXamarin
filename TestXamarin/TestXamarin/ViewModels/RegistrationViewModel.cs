using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Input;
using FreeSurgut.Views;
using TestXamarin.Models;
using TestXamarin.ViewModels;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        private RegistrationPage _page;
        private ICommand _goToLoginPage;

        public ICommand GoToLoginPage => _goToLoginPage ?? new Command(() =>
        {
            _page.Navigation.PopAsync();
            _page.Navigation.PushModalAsync(new LoginPage());
        }, () => true);
        private ICommand _registrationCommand;

        public ICommand RegistrationCommand => _registrationCommand ?? new Command(() =>
        {
            var res = FirstRegRequest();
            if (res is null || res.StatusCode != HttpStatusCode.OK)
            {
                _page.DisplayAlert("Step1", res.ToString(), "Ok");
                return;
            }
            (App.Current as App).TheUser = new User
            {
                Email = this.Email,
                Password = this.Password,
                UserName = this.Username,
                RealName = this.RealName,
                Reports = new System.Collections.ObjectModel.ObservableCollection<Report>(),
                Achievements = new System.Collections.ObjectModel.ObservableCollection<Achievement>()
            };
            _page.Navigation.PopModalAsync();
        }, () => true);

        private string _email; 
        public string Email 
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
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
        public string Password 
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string _confirmPasswrod;
        public string ConfirmPassword 
        {
            get => _confirmPasswrod;
            set
            {
                _confirmPasswrod = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }
        private string _accessToken;
        private string _realName;
        public string RealName 
        {
            get => _realName;
            set
            {
                _realName = value;
                OnPropertyChanged(nameof(RealName));
            }
        }
        public RegistrationViewModel(RegistrationPage page)
        {
            _page = page;
            Title = "Регистрация";
        }
        public IRestResponse FirstRegRequest()
        {
            var client = new RestClient("http://188.225.83.42:8080/registration/");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("name", Username);
            request.AddParameter("real_name", RealName);
            request.AddParameter("password", Password);
            request.AddParameter("email", Email);
            request.AddParameter("send_report", "0");
            request.AddParameter("decline_report", "0");
            request.AddParameter("proccessing_report", "0");
            IRestResponse response = client.Execute(request);
            return response;
        }
        //public IRestResponse SecondRegRequest()
        //{
        //    //2nd Step 
        //    var registration = new RestClient("http://188.225.83.42:8080/auth/jwt/create/") { Timeout = 50 };
        //    var reg2 = new RestRequest(Method.POST);
        //    reg2.AddParameter("username", "token_man");
        //    reg2.AddParameter("password", "Hakaton12345");
        //    var response = registration.Execute(reg2);
        //    if (response.StatusCode != HttpStatusCode.OK) return response;
        //    string json = response.Content;
        //    JObject jObject = JObject.Load(new JsonTextReader(new StringReader(json)));
        //    _accessToken = jObject["access"]?.ToString();
        //    return response;
        //}
        //public IRestResponse ThirdRegRequest()
        //{
        //    //3rd Step
        //    var registartion = new RestClient("http://188.225.83.42:8080/registration/create-full-profile") { Timeout = 50 };
        //    var reg3 = new RestRequest(Method.GET);
        //    reg3.AddHeader("Authorization", $"Bearer {_accessToken}");
        //    reg3.AddParameter("user_name", Username)
        //        .AddParameter("user_real_name", RealName)
        //        .AddParameter("user_email", Email)
        //        .AddParameter("recieved_reports", "0")
        //        .AddParameter("send_reports", "0")
        //        .AddParameter("decline_reports", "0")
        //        .AddParameter("processing_reports", "0");
        //    var response = registartion.Execute(reg3);
        //    return response;
        //}
    }
}
