using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace PetsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterController : ControllerBase
    {
        private readonly IFooterService _footerService;

        public FooterController(IFooterService footerService)
        {
            _footerService = footerService;
        }

        [HttpGet]
        public IActionResult FooterList()
        {
            var values = _footerService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddFooter(Footer footer)
        {
            _footerService.TInsert(footer);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFooter(int id)
        {
            var values = _footerService.TGetByID(id);
            _footerService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateFooter(Footer footer)
        {
            _footerService.TUpdate(footer);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetFooter(int id)
        {
            var values = _footerService.TGetByID(id);
            return Ok(values);
        }
    }
}
