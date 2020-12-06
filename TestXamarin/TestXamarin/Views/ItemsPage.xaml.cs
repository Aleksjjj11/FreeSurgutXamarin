using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestXamarin.Models;
using TestXamarin.Views;
using TestXamarin.ViewModels;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Collections.ObjectModel;
using FreeSurgut.Views;

namespace TestXamarin.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            LayoutChanged += (o, e) =>
            {
                UpdateChildrenLayout();
            };
            BindingContext = viewModel = new ItemsViewModel();
            InitializeComponent();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Report)layout.BindingContext;
            await Navigation.PushAsync(new ReportPage(new ReportDetailViewModel(item)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.IsBusy = true;
            try
            {
                if ((App.Current as App).TheUser is null) throw new Exception("User is null");

                try
                {
                    //Get main users info 
                    var client = new RestClient("http://188.225.83.42:8080/login/");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AlwaysMultipartFormData = true;
                    request.AddParameter("name", (App.Current as App).TheUser.UserName);
                    request.AddParameter("password", (App.Current as App).TheUser.Password);
                    IRestResponse response = client.Execute(request);
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                        DisplayAlert("Error", "Ошибка при обновлении данных. Требуется проверить подключение к интернету.", "Ok");
                    var jObject = JObject.Load(new JsonTextReader(new StringReader(response.Content)));
                    (App.Current as App).TheUser.RealName = jObject["real_name"]?.ToString();
                    (App.Current as App).TheUser.UserName = jObject["name"]?.ToString();
                    (App.Current as App).TheUser.Email = jObject["email"]?.ToString();
                    (App.Current as App).TheUser.Achievements = new ObservableCollection<Achievement>();

                    //Get reports' info of user 
                    client = new RestClient("http://188.225.83.42:8080/pull_report/");
                    client.Timeout = -1;
                    request = new RestRequest(Method.POST);
                    request.AlwaysMultipartFormData = true;
                    request.AddParameter("name", (App.Current as App).TheUser.UserName);
                    response = client.Execute(request);
                    jObject = JObject.Load(new JsonTextReader(new StringReader(response.Content)));
                    int countReport = Convert.ToInt32(jObject["len"]);
                    var updatedReports = new ObservableCollection<Report>();
                    for (int i = 0; i < countReport; i++)
                    {
                        var report = JObject.Load(new JsonTextReader(new StringReader(jObject[$"{i}"]?.ToString())));
                        var item = new Report
                        {
                            NumberCar = report["car_number"]?.ToString().Split(' ').First(),
                            RegionCar = 186 + " " + report["car_number"]?.ToString().Split(' ').Last(),
                            Description = report["description"]?.ToString(),
                            PathsReportImages = new ObservableCollection<string>
                            {
                                $"{report["image1_link"]?.ToString()}",
                                $"{report["image2_link"]?.ToString()}",
                                $"{report["image3_link"]?.ToString()}"
                            }
                        };
                        updatedReports.Add(item);
                    }

                    (App.Current as App).TheUser.Reports = updatedReports;
                }
                catch (Exception exp)
                {
                    DisplayAlert("Error", exp.Message, "Ok");
                }
            } catch (Exception ex)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
            //    =  new User
            //{
            //    RealName = jObject["user_real_name"]?.ToString(),
            //    UserName = jObject["user_name"]?.ToString(),
            //    Email = jObject["user_email"]?.ToString(),
            //    Password = (App.Current as App).TheUser.Password,
            //    Reports = new ObservableCollection<Report>(),
            //    Achievements = new ObservableCollection<Achievement>()
            //};
        }

    }
}