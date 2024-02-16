using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBM07Feb2024_FormsAuthAspMVC5.Models
{
    public class POViewModel
    {

        public Models.PurchaseOrderHeader POHeader { get; set; }
        public Models.PurchaseOrderProductLine POProductLine { get; set; }
        public Models.PurchaseOrderProductLine[] POProductLines { get; set; }
    }

    public class DrugModel
    {
        public int DrugID { get; set; }
        public string DrugName { get; set;}

    }
}