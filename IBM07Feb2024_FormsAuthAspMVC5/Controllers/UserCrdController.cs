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
                    CurrentUserModel cusr = new CurrentUserModel();
                    cusr.UserName = usr.UserName;
                   cusr.ReferenceToId=usr.ReferenceToId;
                    cusr.UserID=usr.UserID; 
                    cusr.Role = usr.Role;

                    if (usr.Role== "PHYSICIAN") {

                        cusr.FirstName = _db.Physicians.Find(usr.ReferenceToId).FirstName;
                        cusr.LastName = _db.Physicians.Find(usr.ReferenceToId).LastName;
                    }



                    Session["CurrentUser"]= cusr;
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