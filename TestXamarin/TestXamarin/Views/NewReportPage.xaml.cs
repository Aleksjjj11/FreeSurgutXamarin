using Android.App;
using Android.Widget;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using TestXamarin.Models;
using TestXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewReportPage : ContentPage
    {
        NewReportViewModel viewModel;
        public NewReportPage()
        {
            BindingContext = viewModel = new NewReportViewModel();
            InitializeComponent();
            ButtonPickPhoto.Clicked += ButtonPickPhoto_Clicked;
        }
        
        private async void ButtonPickPhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            viewModel.Report.ReportImages.Clear();
            if (!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Message", "EBANIY ERROR", "ok:");
            }
            else
            {
                var res = await CrossMedia.Current.PickPhotosAsync(new PickMediaOptions 
                { 
                    PhotoSize = PhotoSize.Large,
                    
                }, new MultiPickerOptions 
                {
                    MaximumImagesCount = 3
                });
                if (res is null) return;
                foreach (var photo in res)
                {
                    viewModel.Report.ReportImages.Add(new Image() { Source=photo.Path });
                }
                ImagesView.ItemsSource = viewModel.Report.ReportImages;
            }
            if (viewModel.Report.NumberCar?.Length == 6 && viewModel.Report.Country?.ToUpper() == "RUS" &&
                viewModel.Report?.RegionCar != "" && viewModel.Report.ReportImages.Count > 2)
                ButtonSendReport.IsVisible = true;
            //if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            //{
            //    MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            //    {
            //        PhotoSize = PhotoSize.Medium,
            //        CompressionQuality = 40,
            //        SaveToAlbum = true,
            //        Directory = "sample",
            //        Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
            //    });

            //    if (file == null)
            //        return;

            //    //viewModel.Report.ReportImages.Add(new Image());
            //    //viewModel.Report.ReportImages.Last().Source = LastImage.Source = ImageSource.FromFile(file.Path);
            //}
        }

        private void ButtonSendReport_Clicked(object sender, EventArgs e)
        {
            //Здесь будет происходить отправка репорта на сервер ГИБДД для раccмотрения
            viewModel.Report.Status = Report.ReportStatus.Processing;
            (App.Current as App).TheUser.Reports.Add(viewModel.Report);
            Toast.MakeText(Android.App.Application.Context, "Ваша жалоба отправлена на рассмотрение! ^_^", ToastLength.Long).Show();
            ButtonSendReport.IsVisible = false;
            BindingContext = viewModel = new NewReportViewModel();
            ImagesView.ItemsSource = viewModel.Report.ReportImages;
        }
        private void Entry_Completed(object sender, EventArgs e)
        {
            if (viewModel.Report.NumberCar?.Length == 6 && viewModel.Report.Country?.ToUpper() == "RUS" &&
                viewModel.Report?.RegionCar != "" && viewModel.Report.ReportImages.Count > 2)
                ButtonSendReport.IsVisible = true;
            else
                ButtonSendReport.IsVisible = false;
        }
    }
}