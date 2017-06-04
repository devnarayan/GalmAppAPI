using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalmApp.Api.ViewModel
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string ThumbImg { get; set; }
        public string BackgroundImg { get; set; }

        public List<PackageViewModel> Packages { get; set; }
    }
}