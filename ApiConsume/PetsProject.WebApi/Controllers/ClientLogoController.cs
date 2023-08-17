using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace PetsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientLogoController : ControllerBase
    {
        private readonly IClientLogoService _clientLogoService;

        public ClientLogoController(IClientLogoService clientLogoService)
        {
            _clientLogoService = clientLogoService;
        }

        [HttpGet]
        public IActionResult ClientLogoList()
        {
            var values = _clientLogoService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddClientLogo(ClientLogo clientLogo)
        {
            _clientLogoService.TInsert(clientLogo);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClientLogo(int id)
        {
            var values = _clientLogoService.TGetByID(id);
            _clientLogoService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateClientLogo(ClientLogo clientLogo)
        {
            _clientLogoService.TUpdate(clientLogo);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetClientLogo(int id)
        {
            var values = _clientLogoService.TGetByID(id);
            return Ok(values);
        }
    }
}
