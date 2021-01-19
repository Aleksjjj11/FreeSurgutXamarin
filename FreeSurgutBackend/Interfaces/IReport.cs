using System;
using System.Collections.ObjectModel;

namespace FreeSurgutBackend.Interfaces
{
    public interface IReport
    {
        public ObservableCollection<string> PathsReportImages { get; set; }
        public IUser Owner { get; }
        public ReportStatus Status { get; set; }
        public string NumberCar { get; set; }
        public string Country { get; set; }
        public string RegionCar { get; set; }
        public string CountryImage { get; }
        public DateTime CreatedDate { get; }
        public string Date { get; }
        public string Time { get; }
    }
    public enum ReportStatus
    {
        Accepted,
        Declined,
        Processing
    }
}
