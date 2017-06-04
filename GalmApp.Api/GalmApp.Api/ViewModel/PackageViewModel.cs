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
    }
}