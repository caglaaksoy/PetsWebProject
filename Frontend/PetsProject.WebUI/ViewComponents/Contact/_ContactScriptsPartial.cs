using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Contact
{
    public class _ContactScriptsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
