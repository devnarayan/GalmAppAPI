using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalmApp.Api.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsPaymentDone { get; set; }

        public List<BookingPackageViewModel> Packages { get; set; }
    }

    public class BookingPackageViewModel
    {
        public int BookingPackageId { get; set; }
        public Nullable<int> PackageId { get; set; }
        public Nullable<int> BookingId { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}