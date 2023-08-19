using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.About
{
    public class _AboutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
