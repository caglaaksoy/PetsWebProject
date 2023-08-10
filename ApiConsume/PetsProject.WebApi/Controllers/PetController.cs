using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace PetsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IActionResult PetList()
        {
            var values = _petService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddPet(Pet Pet)
        {
            _petService.TInsert(Pet);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletePet(int id)
        {
            var values = _petService.TGetByID(id);
            _petService.TDelete(values);
            return Ok();
        }


        [HttpPut]
        public IActionResult UpdatePet(Pet pet)
        {
            _petService.TUpdate(pet);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPet(int id)
        {
            var values = _petService.TGetByID(id);
            return Ok(values);
        }
    }
}
