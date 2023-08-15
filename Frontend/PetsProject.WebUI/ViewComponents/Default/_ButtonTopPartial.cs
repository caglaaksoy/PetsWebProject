using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Default
{
    public class _ButtonTopPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
