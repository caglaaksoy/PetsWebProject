using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Default
{
    public class _HeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
