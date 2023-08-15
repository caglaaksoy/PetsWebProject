using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Default
{
    public class _FeaturePartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
