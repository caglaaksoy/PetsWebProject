using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.BlogList
{
    public class _BlogListSidePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
