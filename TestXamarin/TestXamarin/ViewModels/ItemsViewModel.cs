using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TestXamarin.Models;
using TestXamarin.Views;

namespace TestXamarin.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Report> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Журнал";
            Items = new ObservableCollection<Report>((App.Current as App).TheUser.Reports);
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

           /* MessagingCenter.Subscribe<NewItemPage, Report>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Report;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
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
                    Items.Add((Report)item);
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