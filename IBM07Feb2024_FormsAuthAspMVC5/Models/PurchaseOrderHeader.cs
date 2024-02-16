//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IBM07Feb2024_FormsAuthAspMVC5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseOrderHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrderHeader()
        {
            this.PurchaseOrderProductLines = new HashSet<PurchaseOrderProductLine>();
        }
    
        public int PurchaseOrderID { get; set; }
        public Nullable<System.DateTime> PODate { get; set; }
        public int SupplierID { get; set; }
        public string Note { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderProductLine> PurchaseOrderProductLines { get; set; }
    }
}
