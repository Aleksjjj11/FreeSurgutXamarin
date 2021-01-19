using System.Collections.ObjectModel;
using System.Linq;
using FreeSurgutBackend.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeSurgutBackend.Models
{
    public class User : IUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ObservableCollection<IReport> Reports { get; set; }
        public ObservableCollection<IAchievement> Achievements { get; set; }
        public int CountAccepted 
            => Reports is null ? 0 : Reports.Count(rep => rep.Status == ReportStatus.Accepted);

        public int CountDeclined 
            => Reports is null ? 0 : Reports.Count(rep => rep.Status == ReportStatus.Declined);

        public int CountProcessing 
            => Reports is null ? 0 : Reports.Count(rep => rep.Status == ReportStatus.Processing);
    }
}
