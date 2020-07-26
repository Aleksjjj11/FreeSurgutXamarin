using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestXamarin.Models
{
    class Report : Item
    {
        public List<Image> ReportImages { get; set; }
        public int OwnerId { get; }
        public string ReportStatus { get; }
    }
}
