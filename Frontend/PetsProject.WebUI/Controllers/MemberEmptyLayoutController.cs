using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.Controllers
{
    public class MemberEmptyLayoutController : Controller
    {
        public IActionResult _MemberEmptyLayout()
        {
            return View();
        }

        public PartialViewResult MemberHeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult MemberHeaderPartial()
        {
            return PartialView();
        }


        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ButtonTopPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
