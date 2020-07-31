using System;
using System.Collections.Generic;
using System.Text;
using TestXamarin.Models;
using Xamarin.Forms;

namespace TestXamarin.ViewModels
{
    public class NewReportViewModel : BaseViewModel
    {
        public Report report;
        public NewReportViewModel()
        {
            Title = "Новая жалоба";
            report = new Report();
        }
    }
}
