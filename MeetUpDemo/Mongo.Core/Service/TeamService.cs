using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Mongo.Core
{
    public class TeamService
    {

        private readonly IMongoCollection<Team> _teams;

        public TeamService(IMongoDbSettings settings)
        {
            MongoClient mongoClient = new MongoClient(settings.ConnectionString);
            var db = mongoClient.GetDatabase(settings.Database);
            _teams = db.GetCollection<Team>(settings.Collection);

        }

        public List<Team> GetAll() => _teams.Find(t => true).ToList();

        public Team GetSingle(string id) => _teams.Find(x => x.Id == id).FirstOrDefault();

        public Team Create(Team team)
        {
            _teams.InsertOne(team);
            return team;
        }

        public long Delete(string id) => _teams.DeleteOne(x => x.Id == id).DeletedCount;

        public long Update(string id, Team currentTeam) => _teams.ReplaceOne(x => x.Id == id , currentTeam).ModifiedCount;


    }
}