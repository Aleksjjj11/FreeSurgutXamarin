using System;
using System.Collections.Generic;
using System.Globalization;
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
        public DateTime CreatedDate { get; private set; }
        public string Date
        {
            get
            {
                return $"{CreatedDate.Day}.{CreatedDate.Month}.{CreatedDate.Year}";
            }
        }
        public string Time
        {
            get
            {
                return CreatedDate.ToString("t", new CultureInfo("hr-HR"));
            }
        }
        public Color ColorStatus 
        { 
            get { 
                switch (Status)
                {
                    case ReportStatus.Accepted: return Color.FromHex("#228B22");
                    case ReportStatus.Declined: return Color.FromHex("#B22222");
                    case ReportStatus.Processing: return Color.FromHex("#008B8B");
                    default: return Color.Black;
                }
            }   
        }
        public string StringStatus
        {
            get
            {
                switch (Status)
                {
                    case ReportStatus.Accepted: return "Принято";
                    case ReportStatus.Declined: return "Отклонено";
                    case ReportStatus.Processing: return "Обрабатывается";
                    default: return null;
                }
            }
        }
        public Report()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
