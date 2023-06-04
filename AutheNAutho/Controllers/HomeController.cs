using AutheNAutho.Auth;
using AutheNAutho.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace AutheNAutho.Controllers
{
    [CustomAuthenticationFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize("Super Admin","Admin")]
        public ActionResult ListOfUser()
        {
            UserDB obj=new UserDB();
            ViewBag.UserList = obj.UserList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}