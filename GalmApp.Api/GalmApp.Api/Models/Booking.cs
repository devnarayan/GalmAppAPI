//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalmApp.Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.BookingPackages = new HashSet<BookingPackage>();
        }
    
        public int BookingId { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsPaymentDone { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingPackage> BookingPackages { get; set; }
    }
}
