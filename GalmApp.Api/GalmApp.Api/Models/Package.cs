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
    
    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            this.PackagePrices = new HashSet<PackagePrice>();
            this.BookingPackages = new HashSet<BookingPackage>();
        }
    
        public int PackageId { get; set; }
        public int ServiceId { get; set; }
        public string Duration { get; set; }
        public string PackageName { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string PackageDescription { get; set; }
    
        public virtual Service Service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PackagePrice> PackagePrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingPackage> BookingPackages { get; set; }
    }
}
