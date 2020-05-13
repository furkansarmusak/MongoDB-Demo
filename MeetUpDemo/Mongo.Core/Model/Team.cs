using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Core
{
    public class Team
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("region")]
        public string Region { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("abbrev")]
        public string Abbrevetion { get; set; }

        [BsonElement("pop")]
        public double Popularity { get; set; }

    }
}