using System;
using System.Collections.Generic;
using System.Text;
using TestXamarin.Models;

namespace TestXamarin.ViewModels
{
    public class ReportDetailViewModel : ItemDetailViewModel
    {
        public Report Item { get; set; }
        public ReportDetailViewModel(Report item = null)
        {
            Title = $"Жалоба на {item.NumberCar}";
            Item = item;
        }
    }
}
