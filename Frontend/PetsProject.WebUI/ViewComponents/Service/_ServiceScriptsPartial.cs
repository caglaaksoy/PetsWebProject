using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Service
{
    public class _ServiceScriptsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
