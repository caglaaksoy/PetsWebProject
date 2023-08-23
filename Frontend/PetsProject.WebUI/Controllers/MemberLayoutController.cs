using Microsoft.AspNetCore.Mvc;

namespace PetsProject.WebUI.Controllers
{
    public class MemberLayoutController : Controller
    {
        public IActionResult _MemberLayout()
        {
            return View();
        }

        public PartialViewResult HeadMemberPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeaderMemberPartial()
        {
            return PartialView();
        }
        //public PartialViewResult SidebarMemberPartial()
        //{
        //    return PartialView();
        //}

        //public PartialViewResult FooterMemberPartial()  //FOREACH HATASI İÇİN SONRA BAK
        //{
        //    return PartialView();
        //}

        public PartialViewResult ScriptMemberPartial()
        {
            return PartialView();
        }


    }
}
