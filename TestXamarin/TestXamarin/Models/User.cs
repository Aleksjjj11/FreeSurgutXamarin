using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestXamarin.Models
{
    public class User : Item
    {
        public string UserName { get; }
        public ObservableCollection<Report> Reports { get; set; }
        public ObservableCollection<Achievement> Achievements { get; }
        public int CountAccepted
        {
            get => Reports.Where(rep => rep.Status == Report.ReportStatus.Accepted).Count();
        }
        public int CountDeclined
        {
            get => Reports.Where(rep => rep.Status == Report.ReportStatus.Declined).Count();
        }
        public int CountProcessing
        {
            get => Reports.Where(rep => rep.Status == Report.ReportStatus.Processing).Count();
        }

        public User(string name, string status, ObservableCollection<Achievement> achievements)
        {
            this.UserName = name;
            this.Description = status;
            this.Achievements = achievements;
        }
    }
}
