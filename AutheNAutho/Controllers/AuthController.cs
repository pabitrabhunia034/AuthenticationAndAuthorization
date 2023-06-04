using AutheNAutho.DB;
using AutheNAutho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutheNAutho.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View("LoginPage");
        }
        public ActionResult UnAuthorize()
        {
            return View("UnAuthorize");
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                UserDB db=new UserDB();
                var user = db.UserList().FirstOrDefault(u=>u.Email==loginModel.Email && u.Password==loginModel.Password);
                if (user!=null)
                {
                    Session["UserId"]=user.Id;
                    Session["WlcMsg"] = user.Name;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.LoginMsg = "Invalid User";
            }
            return View("LoginPage");
        }
        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            Session["WlcMsg"] = null;
           
            return View("LoginPage");
        }
    }
}