using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mongo.Core;
using System.Collections.Generic;
using Xunit.Sdk;

namespace Mongo.Test
{
    [TestClass]
    public class TeamServiceTest
    {

        private TeamService service;

        [TestInitialize]
        public void Setup()
        {
            IMongoDbSettings settings = new MongoDbSettings
            {
                Collection = "teams",
                ConnectionString = "mongodb://localhost:27017",
                Database = "NBADatabase"
            };
            service = new TeamService(settings);
        }

        [TestMethod]
        public void GetAll_Should_Return_Teams()
        {
            var teams = service.GetAll();
            Assert.AreNotEqual(0, teams.Count);
        }

        [TestMethod]
        public void GetSingle_Should_Return_Any_Team_By_Id()
        {
            string id = "5ebb5b6898a7e2d37736de11";
            Team team = service.GetSingle(id);
            Assert.AreNotEqual(null, team);
            Assert.AreEqual("BOS", team.Abbrevetion);
        }
        [TestMethod]
        public void Create_Should_New_Team()
        {
            Team team = new Team();
            var inserted = service.Create(team);
            Assert.AreNotEqual(0, inserted.Id);
            Assert.AreEqual(24, inserted.Id.Length);

        }


        [TestMethod]
        public void Delete_Should_Remove_Team()
        {
            var id = "5ebc6a1922b08634883b9558";
            var deletedCount = service.Delete(id);
            Assert.AreEqual(1, deletedCount);

        }

        [TestMethod]
        public void Update_Should_Change_Team_Name()
        {
            var id = "5ebb5b6898a7e2d37736de12";
            Team currentTeam = new Team
            {
                Id= "5ebb5b6898a7e2d37736de12",
                Name = "Trabzon"
            };
            long updatedCount = service.Update(id, currentTeam);
            Assert.AreEqual(1, updatedCount);

        }


    }
}
