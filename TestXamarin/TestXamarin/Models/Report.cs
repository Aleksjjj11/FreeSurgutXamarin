using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestXamarin.Models
{
    public class Report : Item
    {
        public enum ReportStatus
        {
            Accepted,
            Declined,
            Processing
        }
        public List<Image> ReportImages { get; set; }
        public User Owner { get; }
        public ReportStatus Status { get; set; }
        public string NumberCar { get; set; }
        public string Country { get; set; }
        public int RegionCar { get; set; }
    }
}
