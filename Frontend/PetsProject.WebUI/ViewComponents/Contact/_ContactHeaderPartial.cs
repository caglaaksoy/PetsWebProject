using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.ViewComponents.Contact
{
    public class _ContactHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
