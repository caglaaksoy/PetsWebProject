using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace PetsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopProcessController : ControllerBase
    {
        private readonly IShopProcessService _shopProcessService;

        public ShopProcessController(IShopProcessService shopProcessService)
        {
            _shopProcessService = shopProcessService;
        }

        [HttpGet]
        public IActionResult ShopProcessList()
        {
            var values = _shopProcessService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddShopProcess(ShopProcess shopProcess)
        {
            _shopProcessService.TInsert(shopProcess);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShopProcess(int id)
        {
            var values = _shopProcessService.TGetByID(id);
            _shopProcessService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateShopProcess(ShopProcess shopProcess)
        {
            _shopProcessService.TUpdate(shopProcess);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetShopProcess(int id)
        {
            var values = _shopProcessService.TGetByID(id);
            return Ok(values);
        }
    }
}
