using System.Collections.ObjectModel;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeSurgutBackend.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ObservableCollection<Report> Reports { get; set; }
        public ObservableCollection<Achievement> Achievements { get; set; }
        public int CountAccepted 
            => Reports is null ? 0 : Reports.Count(rep => rep.Status == Report.ReportStatus.Accepted);

        public int CountDeclined 
            => Reports is null ? 0 : Reports.Where(rep => rep.Status == Report.ReportStatus.Declined).Count();

        public int CountProcessing 
            => Reports is null ? 0 : Reports.Where(rep => rep.Status == Report.ReportStatus.Processing).Count();
    }
}
