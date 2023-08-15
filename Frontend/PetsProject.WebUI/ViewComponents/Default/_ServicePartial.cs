using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Default
{
    public class _ServicePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
