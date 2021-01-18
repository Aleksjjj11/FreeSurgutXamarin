
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeSurgutBackend.Models
{
    public class Achievement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IconUri { get; set; }
    }
}
