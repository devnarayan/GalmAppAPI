using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalmApp.Api.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
    }
}