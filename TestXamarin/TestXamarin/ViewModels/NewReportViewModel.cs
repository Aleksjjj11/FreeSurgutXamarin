using System;
using System.Collections.Generic;
using System.Text;
using TestXamarin.Models;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    public class NewReportViewModel : BaseViewModel
    {
        public Report Report { get; set; }
        public NewReportViewModel()
        {
            Title = "Новая жалоба";
            Report = Report ?? new Report();
        }
    }
}
