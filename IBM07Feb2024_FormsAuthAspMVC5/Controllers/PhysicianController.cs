using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM07Feb2024_FormsAuthAspMVC5.Controllers
{
    public class PhysicianController : Controller
    {
     [Authorize(Roles = "PHYSICIAN")]
       
        public ActionResult Index()
        {
            return View();
        }
    }
}