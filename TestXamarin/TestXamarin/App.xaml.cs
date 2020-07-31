using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestXamarin.Services;
using TestXamarin.Views;
using TestXamarin.Models;
using System.Collections.Generic;

namespace TestXamarin
{
    public partial class App : Application
    {
        public User TheUser { get; set; }

        public App()
        {
            InitializeComponent();
            TheUser = new User("de401t", "Николай", new List<Achievement>()
                {
                    new Achievement { Text = "Дикий ловец", Description = "Поймать 100 нарушителей", Id = Guid.NewGuid().ToString(), IconUri = "Achivement_logo.png" },
                    new Achievement { Text = "Ночной угодник", Description= "Поймать нарушителя ночью", Id = Guid.NewGuid().ToString(), IconUri = "Achivement_logo_silver.png" }
                })
            {
                Id = Guid.NewGuid().ToString(),
                Reports = new List<Report>() { new Report { Status = Report.ReportStatus.Accepted, NumberCar = "A436УВ", Country = "RUS", RegionCar = 777, ReportImages = new List<Image> { new Image { Source = "car2.png" } } },
                new Report { Status = Report.ReportStatus.Declined, NumberCar = "В325АН", Country = "RUS", RegionCar = 94, ReportImages = new List<Image> { new Image { Source = "auto_04.jpg" }, new Image { Source = "auto_04.jpg" }, new Image { Source = "auto_04.jpg" } } } }
            };
            //Сделать нормальные констуркторы, даун(для кода сверху)
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
