using MongoDB.Driver;

namespace Mongo.Core
{
    public interface IMongoDbSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }
}