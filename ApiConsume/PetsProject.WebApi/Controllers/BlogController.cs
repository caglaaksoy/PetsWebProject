using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetsProject.BusinessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;

namespace PetsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult BlogList()
        {
            var values = _blogService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            _blogService.TInsert(blog);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var values = _blogService.TGetByID(id);
            _blogService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBlog(Blog blog)
        {
            _blogService.TUpdate(blog);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var values = _blogService.TGetByID(id);
            return Ok(values);
        }

    }
}
