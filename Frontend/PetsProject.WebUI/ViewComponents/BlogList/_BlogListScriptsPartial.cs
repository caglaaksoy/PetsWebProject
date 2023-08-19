using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.BlogList
{
    public class _BlogListScriptsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
