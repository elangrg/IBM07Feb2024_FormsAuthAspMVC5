using IBM07Feb2024_FormsAuthAspMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace IBM07Feb2024_FormsAuthAspMVC5.Controllers
{
    public class UserCrdController : Controller
    {
        // GET: UserCrd
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {

                Models.CredentialDbEntities _db = new CredentialDbEntities();

                UserCred usr = _db.UserCreds.SingleOrDefault(dbusr => dbusr.UserName.ToLower() == user
               .UserName.ToLower() && dbusr.Password == user.Password);

                if (usr!=null)
                {
                    FormsAuthentication.SetAuthCookie(usr.UserName, false);
                    return RedirectToAction("Index", usr.Role);
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }





        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}