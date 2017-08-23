using GalmApp.Api.Models;
using GalmApp.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;

namespace GalmApp.Api.Controllers
{
    [Authorize]
    public class BookingController : ApiController
    {
        #region Booking
        [Route("AddBooking")]
        [ResponseType(typeof(BookingViewModel))]
        public IHttpActionResult AddBooking(BookingViewModel model)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                if (model.BookingDate == null) model.BookingDate = DateTime.UtcNow;
                AutoMapper.Mapper.CreateMap<BookingViewModel, Booking>();
                var book = AutoMapper.Mapper.Map<Booking>(model);
                dbContext.Bookings.Add(book);
                dbContext.SaveChanges();

                if (model.Packages != null)
                {
                    AutoMapper.Mapper.CreateMap<BookingPackageViewModel, BookingPackage>();
                    foreach (var pkg in model.Packages)
                    {
                        var package = AutoMapper.Mapper.Map<BookingPackage>(pkg);
                        package.BookingId = book.BookingId;
                        dbContext.BookingPackages.Add(package);
                    }
                    dbContext.SaveChanges();
                }
                return Ok(new ResponseModel {Data=book, Status="Success", Message="Added Booking Successfully."});
            }
        }

        [Route("GetBookingByUser")]
        [ResponseType(typeof(List<BookingViewModel>))]
        public IHttpActionResult GetBooking(string userName)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Bookings.Where(st => st.UserName == userName).ToList();
                AutoMapper.Mapper.CreateMap<Booking, BookingViewModel>()
                  .ForMember(d => d.Packages, opt => opt.MapFrom(d => d.BookingPackages));
                AutoMapper.Mapper.CreateMap<BookingPackage, BookingPackageViewModel>();

                var book = AutoMapper.Mapper.Map<List<BookingViewModel>>(data);
                return Ok(new ResponseModel {Data=book, Status = "Success", Message = "Booking data vai UserName" });
            }
        }

        [Route("GetBookingUpcommingByUser")]
        [ResponseType(typeof(List<BookingViewModel>))]
        public IHttpActionResult GetBookingUpcommingByUser(string userName, int days)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Bookings.Where(st => st.UserName == userName && st.BookingDate.Value >= DateTime.Now.AddDays(-days)).ToList();
                AutoMapper.Mapper.CreateMap<Booking, BookingViewModel>()
                    .ForMember(d => d.Packages, opt => opt.MapFrom(d => d.BookingPackages));
                AutoMapper.Mapper.CreateMap<BookingPackage, BookingPackageViewModel>();

                var book = AutoMapper.Mapper.Map<List<BookingViewModel>>(data);
                return Ok(new ResponseModel {Data=book, Status = "Success", Message = "Get Upcomming Booking by Username." });
            }
        }
        #endregion

        #region FAQ
        [Route("GetFAQ")]
        [ResponseType(typeof(FAQViewModel))]
        public IHttpActionResult GetBooking(int userId, int days)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.FAQs.ToList();
                AutoMapper.Mapper.CreateMap<FAQ, FAQViewModel>();
                var faq = AutoMapper.Mapper.Map<List<FAQViewModel>>(data);
                return Ok(new ResponseModel { Data=faq, Status = "Success", Message = "Get FAQ List." });
            }
        }
        #endregion

        #region Services
        [Route("AddService")]
        [ResponseType(typeof(Service))]
        public IHttpActionResult AddService(ServiceViewModel model)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                AutoMapper.Mapper.CreateMap<ServiceViewModel, Service>();
                var book = AutoMapper.Mapper.Map<Service>(model);
                dbContext.Services.Add(book);
                dbContext.SaveChanges();
                return Ok(new ResponseModel {Data=book, Status = "Success", Message = "Added Service Successfully." });
            }
        }

        [Route("GetServices")]
        [ResponseType(typeof(List<ServiceViewModel>))]
        public IHttpActionResult GetServices()
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Services.ToList();
                AutoMapper.Mapper.CreateMap<Service, ServiceViewModel>().ForMember(d=>d.Packages, opt=>opt.MapFrom(s=>s.Packages));
                AutoMapper.Mapper.CreateMap<Package, PackageViewModel>();
                var book = AutoMapper.Mapper.Map<List<ServiceViewModel>>(data);
                return Ok(new ResponseModel {Data=book, Status = "Success", Message = "Get all service list." });
            }
        }
        [Route("GetServiceById")]
        [ResponseType(typeof(ServiceViewModel))]
        public IHttpActionResult GetServiceById(int serviceId)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Services.Where(st => st.ServiceId == serviceId).FirstOrDefault();
                AutoMapper.Mapper.CreateMap<Service, ServiceViewModel>().ForMember(d => d.Packages, opt => opt.MapFrom(s => s.Packages));
                AutoMapper.Mapper.CreateMap<Package, PackageViewModel>();
                var book = AutoMapper.Mapper.Map<ServiceViewModel>(data);
                return Ok(new ResponseModel {Data=book, Status = "Success", Message = "Get service by service id." });
            }
        }
        #endregion

        #region Packages
        [Route("AddPackage")]
        [ResponseType(typeof(PackageViewModel))]
        public IHttpActionResult AddPackage(PackageViewModel model)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                AutoMapper.Mapper.CreateMap<PackageViewModel, Package>();
                var book = AutoMapper.Mapper.Map<Package>(model);
                dbContext.Packages.Add(book);
                dbContext.SaveChanges();
                return Ok(new ResponseModel {Data=book, Status = "Success", Message = "Add Package Successfully." });
            }
        }

        [Route("GetPackaes")]
        [ResponseType(typeof(List<PackageViewModel>))]
        public IHttpActionResult GetPackaes(int serviceId, int? locationid = 0)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                AutoMapper.Mapper.Reset();
                var data = dbContext.Packages.Where(st => st.ServiceId == serviceId).ToList();
                if (locationid != 0)
                {
                    AutoMapper.Mapper.CreateMap<Package, PackageViewModel>().ForMember(d => d.LocationPrices, opt => opt.MapFrom(d => d.PackagePrices.Where(st => st.LocationId == locationid).ToList()));
                }
                else
                {
                    AutoMapper.Mapper.CreateMap<Package, PackageViewModel>().ForMember(d => d.LocationPrices, opt => opt.MapFrom(d => d.PackagePrices));
                }
                AutoMapper.Mapper.CreateMap<PackagePrice, PackagePriceViewModel>()
                  .ForMember(d => d.LocationName, opt => opt.MapFrom(d => d.Location.LocationName))
                  .ForMember(d => d.CountryCode, opt => opt.MapFrom(d => d.Location.CountryCode))
                  .ForMember(d => d.Country, opt => opt.MapFrom(d => d.Location.Country));
                var book = AutoMapper.Mapper.Map<PackageViewModel>(data);
                return Ok(new ResponseModel { Data=book, Status = "Success", Message = "Get all packages by service id." });
            }
        }
        [Route("GetPackaeById")]
        [ResponseType(typeof(PackageViewModel))]
        public IHttpActionResult GetPackaeById(int packageid, int? locationid = 0)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                AutoMapper.Mapper.Reset();
                var data = dbContext.Packages.Where(st => st.PackageId == packageid).FirstOrDefault();
                if (locationid != 0)
                {
                    AutoMapper.Mapper.CreateMap<Package, PackageViewModel>().ForMember(d => d.LocationPrices, opt => opt.MapFrom(d => d.PackagePrices.Where(st => st.LocationId == locationid).ToList()));
                }
                else
                {
                    AutoMapper.Mapper.CreateMap<Package, PackageViewModel>().ForMember(d => d.LocationPrices, opt => opt.MapFrom(d => d.PackagePrices));
                }
                AutoMapper.Mapper.CreateMap<PackagePrice, PackagePriceViewModel>()
                    .ForMember(d => d.LocationName, opt => opt.MapFrom(d => d.Location.LocationName))
                    .ForMember(d => d.CountryCode, opt => opt.MapFrom(d => d.Location.CountryCode))
                    .ForMember(d => d.Country, opt => opt.MapFrom(d => d.Location.Country));
                var book = AutoMapper.Mapper.Map<PackageViewModel>(data);
                return Ok(new ResponseModel { Data = book, Status = "Success", Message = "Get packages by id." });
            }
        }
        #endregion

        #region Location
        [Route("AddLocation")]
        [ResponseType(typeof(LocationViewModel))]
        public IHttpActionResult AddLocation(LocationViewModel model)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                AutoMapper.Mapper.CreateMap<LocationViewModel, Location>();
                var book = AutoMapper.Mapper.Map<Location>(model);
                dbContext.Locations.Add(book);
                dbContext.SaveChanges();
                return Ok(new ResponseModel { Data = book, Status = "Success", Message = "Add location successfully." });
            }
        }

        [Route("GetLocations")]
        [ResponseType(typeof(List<LocationViewModel>))]
        public IHttpActionResult GetLocations()
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Locations.ToList();
                AutoMapper.Mapper.CreateMap<Location, LocationViewModel>();
                var book = AutoMapper.Mapper.Map<List<LocationViewModel>>(data);
                return Ok(new ResponseModel { Data = book, Status = "Success", Message = "Get all locations" });
            }
        }
        [Route("GetLocationById")]
        [ResponseType(typeof(LocationViewModel))]
        public IHttpActionResult GetLocationById(int locationId)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Locations.Where(st => st.LocationId == locationId).FirstOrDefault();
                AutoMapper.Mapper.CreateMap<Location, LocationViewModel>();
                var book = AutoMapper.Mapper.Map<LocationViewModel>(data);
                return Ok(new ResponseModel { Data = book, Status = "Success", Message = "Get Location by id." });
            }
        }
        [Route("RemoveLocation")]
        public IHttpActionResult RemoveLocation(int locationId)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var location = dbContext.Locations.Where(st => st.LocationId == locationId).FirstOrDefault();
                if (location != null)
                {
                    var locationPrice = dbContext.PackagePrices.Where(st => st.LocationId == locationId).ToList();
                    if (locationPrice != null)
                    {
                        foreach (var price in locationPrice)
                        {
                            dbContext.Entry(price).State = EntityState.Deleted;
                            dbContext.SaveChanges();
                        }
                    }
                    dbContext.Entry(location).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                    var response = new { Status = "Success", Message = "Location removed successfully." };
                    return Ok(response);
                }
                else
                {
                    var response = new { Status = "Fail", Message = "Location not found." };
                    return Ok(response);
                }
            }
        }
        #endregion

    }
}
