using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Default
{
    public class _CtaPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
