using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXamarin.Models;
using TestXamarin.Views;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public User TheUser { get; set; }
        public int CountAccepted 
        { 
            get => TheUser.Reports.Where(rep => rep.Status == Report.ReportStatus.Accepted).Count();  
        }
        public int CountDeclined
        {
            get => TheUser.Reports.Where(rep => rep.Status == Report.ReportStatus.Declined).Count();
        }
        public int CountProcessing
        {
            get => TheUser.Reports.Where(rep => rep.Status == Report.ReportStatus.Processing).Count();
        }

        public ProfileViewModel()
        {
            Title = "Профиль";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //Получение инфы с сервера о пользователе, пока костыль
            TheUser = (App.Current as App).TheUser;
            MessagingCenter.Subscribe<ReportPage, Item>(this, "FullInfoReport", async (obj, item) =>
            {
                /*var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);*/
            });
           /* MessagingCenter.Subscribe<ProfilePage, string>(ProfilePage, "AcceptedInfo", async (sender, arg) =>
            {
                await this.DisplayAlert("Message received", "arg=" + arg, "OK");
            });
            MessagingCenter.Send<ProfileViewModel, int>(this, "AcceptedInfo", TheUser.CountAccepted());*/
           

        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
