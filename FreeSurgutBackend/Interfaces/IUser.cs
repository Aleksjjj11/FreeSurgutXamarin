using System.Collections.ObjectModel;

namespace FreeSurgutBackend.Interfaces
{
    public interface IUser
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ObservableCollection<IReport> Reports { get; set; }
        public ObservableCollection<IAchievement> Achievements { get; set; }
        public int CountAccepted { get; }
        public int CountDeclined { get; }
        public int CountProcessing { get; }
    }
}
