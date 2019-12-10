using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_MTY.Controllers
{
    public class ProfileController : Controller
    {
        // GET: MyProfile
        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }

        public ActionResult UserProfile(string id)
        {
            if (id == null || id == string.Empty)
            {
                return RedirectToAction("Index","Home");
            }
            ViewBag.Id = id;
            return View();
        }


        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}