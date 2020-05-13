using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mongo.Core;

namespace Mongo.API.Controllers
{
    [Route("nba/api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        readonly TeamService _service;

        public TeamsController(IMongoDbSettings settings)
        {
            _service = new TeamService(settings);
        }

        [HttpGet]
        public ActionResult<List<Team>> Get() => _service.GetAll();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Team> Get(string id) => _service.GetSingle(id);

        [HttpPost]
        public ActionResult<Team> Create(Team team) => _service.Create(team);
        
        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Team currentTeam)
        {
            var team = _service.GetSingle(id);
            if (team == null) 
            {
                return NotFound();
            }

            _service.Update(id, currentTeam);
            return Ok();
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            var team = _service.GetSingle(id);
            if (team == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            return Ok();

        }

    }
}