using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestXamarin.Services;
using TestXamarin.Views;
using TestXamarin.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace TestXamarin
{
    public partial class App : Application
    {
        public const string SettingPath = @"SavedSetting.bin";
        public User TheUser { get; set; }

        public App()
        {
            LoadSaving();
            InitializeComponent();
            //Сделать нормальные констуркторы, даун(для кода сверху)
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            SaveInFile();
        }

        protected override void OnResume()
        {
        }
        public static bool LoadSaving()
        {
            string filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SettingPath);
            if (File.Exists(filepath))
            {
                Debug.WriteLine("Reading saved");
                Stream openFileStream = File.OpenRead(filepath);
                BinaryFormatter deserializer = new BinaryFormatter();
                (App.Current as App).TheUser = (User)deserializer.Deserialize(openFileStream);
                //(App.Current as App).TheUser.TimeLastLoaded = DateTime.Now;
                openFileStream.Close();
                Debug.WriteLine(@"Downloaded:");
                return true;
            }

            //(App.Current as App).TheUser = new User("Tasuke", "Николай", new ObservableCollection<Achievement>()
            //    {
            //        new Achievement { Text = "Дикий ловец", Description = "Поймать 100 нарушителей", Id = Guid.NewGuid().ToString(), IconUri = "Achivement_logo.png" },
            //        new Achievement { Text = "Ночной угодник", Description= "Поймать нарушителя ночью", Id = Guid.NewGuid().ToString(), IconUri = "Achivement_logo_silver.png" }
            //    })
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Reports = new ObservableCollection<Report>() { new Report { Status = Report.ReportStatus.Accepted, NumberCar = "A436УВ", Country = "RUS", RegionCar = "777", PathsReportImages = new ObservableCollection<string> { "car2.png" } },
            //    new Report { Status = Report.ReportStatus.Declined, NumberCar = "В325АН", Country = "RUS", RegionCar = "94", PathsReportImages = new ObservableCollection<string> { "auto_04.jpg", "auto_04.jpg", "auto_04.jpg"  } } }
            //};
            //new RegistrationPage(new RegistrationViewModel());
            return false;
        }
        public static void SaveInFile()
        {
            string filepath  = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), SettingPath);
            Stream saveFileStream = File.Create(filepath);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(saveFileStream, (App.Current as App).TheUser);
            saveFileStream.Close();
        }
    }
}
