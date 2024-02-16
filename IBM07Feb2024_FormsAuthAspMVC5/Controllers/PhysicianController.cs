using IBM07Feb2024_FormsAuthAspMVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBM07Feb2024_FormsAuthAspMVC5.Controllers
{
    public class PhysicianController : Controller
    { 
        
        Models.CredentialDbEntities _db = new Models.CredentialDbEntities();


     [Authorize(Roles = "PHYSICIAN")]
       
        public ActionResult Index()
        {
            return View();
        }

  public ActionResult PlacePurchaseOrder()
        {
            var lst = _db.Drugs.ToList().Select(d => new DrugModel { DrugName = d.DrugName, DrugID = d.DrugID }).ToList();

            ViewBag.SupplierID= new SelectList(_db.Suppliers.ToList(), "SupplierID", "FirstName");
            ViewBag.DrugID = new SelectList(lst,"DrugID", "DrugName");
            ViewBag.DrugDataList = lst ;
            
            
            return View();
        }
        [HttpPost]
 public ActionResult PlacePurchaseOrder(Models.POViewModel vm)
        {
            vm.POHeader.Supplier = _db.Suppliers.Find( int.Parse( Request.Form.Get("SupplierID")));


            vm.POProductLines.ToList().ForEach(pl => { vm.POHeader.PurchaseOrderProductLines.Add(pl); });
            _db.PurchaseOrderHeaders.Add(vm.POHeader);

            _db.SaveChanges();


         return RedirectToAction("Index");
        }

    }
}