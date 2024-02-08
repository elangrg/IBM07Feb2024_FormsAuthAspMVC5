using IBM07Feb2024_FormsAuthAspMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM07Feb2024_FormsAuthAspMVC5.Controllers
{
       [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        // GET: Admin
  
       Models.CredentialDbEntities _db= new Models.CredentialDbEntities ();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddNewPhysician()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewPhysician(Models.Physician physician)
        {
            if (ModelState.IsValid) { 
                _db.Physicians.Add(physician);
                _db.SaveChanges();

                UserCred usr = new UserCred();
                usr.ReferenceToId = physician.PhysicianID;
                usr.UserName=physician.FirstName + DateTime.Now.ToString("ddMMyyhhmmss");
                usr.Password = physician.LastName   ;
                usr.Role = "PHYSICIAN";
               
                _db.UserCreds.Add(usr);
                _db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            

            return View();
        }

    }
}