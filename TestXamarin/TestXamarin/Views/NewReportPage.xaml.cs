using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitializeComponent();
            BindingContext = viewModel = new NewReportViewModel();
        }
      
    }
}