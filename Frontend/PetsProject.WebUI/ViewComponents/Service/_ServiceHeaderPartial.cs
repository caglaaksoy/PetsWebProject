using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Service
{
    public class _ServiceHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
