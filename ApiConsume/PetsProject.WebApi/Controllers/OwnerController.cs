using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace OwnersProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult OwnerList()
        {
            var values = _ownerService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddOwner(Owner owner)
        {
            _ownerService.TInsert(owner);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteOwner(int id)
        {
            var values = _ownerService.TGetByID(id);
            _ownerService.TDelete(values);
            return Ok();
        }


        [HttpPut]
        public IActionResult UpdateOwner(Owner owner)
        {
            _ownerService.TUpdate(owner);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetOwner(int id)
        {
            var values = _ownerService.TGetByID(id);
            return Ok(values);
        }
    }
}
