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
    
    public partial class PackagePrice
    {
        public int PackagePriceId { get; set; }
        public Nullable<int> PackageId { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<decimal> Amount { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual Package Package { get; set; }
    }
}
