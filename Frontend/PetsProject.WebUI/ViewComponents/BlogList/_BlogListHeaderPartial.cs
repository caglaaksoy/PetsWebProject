using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.BlogList
{
    public class _BlogListHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
