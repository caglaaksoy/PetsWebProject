using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.About
{
    public class _AboutScriptsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
