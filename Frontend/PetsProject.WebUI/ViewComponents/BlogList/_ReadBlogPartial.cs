using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.BlogList
{
    public class _ReadBlogPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
