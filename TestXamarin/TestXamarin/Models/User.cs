using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestXamarin.Models
{
    [Serializable]
    public class User : Item
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ObservableCollection<Report> Reports { get; set; }
        public ObservableCollection<Achievement> Achievements { get; set; }
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
        public User()
        {
            Reports = new ObservableCollection<Report>();
            Achievements = new ObservableCollection<Achievement>();
        }
    }
}
