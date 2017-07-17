using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalmApp.Api.ViewModel
{
    public class PackageViewModel
    {
        public int PackageId { get; set; }
        public int ServiceId { get; set; }
        public string Duration { get; set; }
        public string PackageName { get; set; }
        public string Currency { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public List<PackagePriceViewModel> LocationPrices { get; set; }
    }
    public class LocationViewModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> AddedOn { get; set; }

    }
    public class PackagePriceViewModel
    {
        public int PackagePriceId { get; set; }
        public Nullable<int> PackageId { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string LocationName { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
    }
}