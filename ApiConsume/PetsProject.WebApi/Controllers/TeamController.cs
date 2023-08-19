using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace PetsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _teamService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _teamService.TInsert(team);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var values = _teamService.TGetByID(id);
            _teamService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTeam(Team team)
        {
            _teamService.TUpdate(team);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var values = _teamService.TGetByID(id);
            return Ok(values);
        }
    }
}
