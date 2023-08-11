using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace PetsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetsService _petsService;

        public PetsController(IPetsService petsService)
        {
            _petsService = petsService;
        }

        [HttpGet]
        public IActionResult PetList()
        {
            var values = _petsService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddPet(Pets pets)
        {
            _petsService.TInsert(pets);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePet(int id)
        {
            var values = _petsService.TGetByID(id);
            _petsService.TDelete(values);
            return Ok();
        }


        [HttpPut]
        public IActionResult UpdatePet(Pets pets)
        {
            _petsService.TUpdate(pets);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPet(int id)
        {
            var values = _petsService.TGetByID(id);
            return Ok(values);
        }
    }
}
