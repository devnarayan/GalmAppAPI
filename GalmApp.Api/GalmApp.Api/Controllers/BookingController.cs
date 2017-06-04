using GalmApp.Api.Models;
using GalmApp.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace GalmApp.Api.Controllers
{
    [Authorize]
    public class BookingController : ApiController
    {
        #region Booking
        [Route("AddBooking")]
        public IHttpActionResult AddBooking(BookingViewModel model)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                if (model.BookingDate == null) model.BookingDate = DateTime.UtcNow;
                AutoMapper.Mapper.CreateMap<BookingViewModel, Booking>();
                var book= AutoMapper.Mapper.Map<Booking>(model);
                dbContext.Bookings.Add(book);
                dbContext.SaveChanges();
                return Ok();
            }
        }

        [Route("GetBookingByUser")]
        public IHttpActionResult GetBooking(string userName)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Bookings.Where(st => st.UserName == userName).ToList();
                AutoMapper.Mapper.CreateMap<Booking, BookingViewModel>();
                var book = AutoMapper.Mapper.Map<List<BookingViewModel>>(data);
                return Ok(book);
            }
        }

        [Route("GetBookingUpcommingByUser")]
        public IHttpActionResult GetBookingUpcommingByUser(string userName, int days)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Bookings.Where(st => st.UserName == userName && st.BookingDate.Value >= DateTime.Now.AddDays(-days)).ToList();
                AutoMapper.Mapper.CreateMap<Booking, BookingViewModel>();
                var book = AutoMapper.Mapper.Map<List<BookingViewModel>>(data);
                return Ok(book);
            }
        }
        #endregion

        #region FAQ
        [Route("GetFAQ")]
        public IHttpActionResult GetBooking(int userId, int days)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.FAQs.ToList();
                AutoMapper.Mapper.CreateMap<FAQ, FAQViewModel>();
                var faq = AutoMapper.Mapper.Map<List<FAQViewModel>>(data);
                return Ok(faq);
            }
        }
        #endregion

        #region Services
        [Route("AddService")]
        public IHttpActionResult AddService(ServiceViewModel model)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                AutoMapper.Mapper.CreateMap<ServiceViewModel, Service>();
                var book = AutoMapper.Mapper.Map<Service>(model);
                dbContext.Services.Add(book);
                dbContext.SaveChanges();
                return Ok();
            }
        }

        [Route("GetServices")]
        public IHttpActionResult GetServices()
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Services.ToList();
                AutoMapper.Mapper.CreateMap<Service, ServiceViewModel>();
                var book = AutoMapper.Mapper.Map<List<ServiceViewModel>>(data);
                return Ok(book);
            }
        }
        [Route("GetServiceById")]
        public IHttpActionResult GetServiceById(int serviceId)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Services.Where(st => st.ServiceId == serviceId).FirstOrDefault();
                AutoMapper.Mapper.CreateMap<Service, ServiceViewModel>();
                var book = AutoMapper.Mapper.Map<ServiceViewModel>(data);
                return Ok(book);
            }
        }
        #endregion

        #region Packages
        [Route("AddPackage")]
        public IHttpActionResult AddPackage(PackageViewModel model)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                AutoMapper.Mapper.CreateMap<PackageViewModel, Package>();
                var book = AutoMapper.Mapper.Map<Package>(model);
                dbContext.Packages.Add(book);
                dbContext.SaveChanges();
                return Ok();
            }
        }

        [Route("GetPackaes")]
        public IHttpActionResult GetPackaes(int serviceId)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Packages.Where(st => st.ServiceId == serviceId).ToList();
                AutoMapper.Mapper.CreateMap<Package, PackageViewModel>();
                var book = AutoMapper.Mapper.Map<List<PackageViewModel>>(data);
                return Ok(book);
            }
        }
        [Route("GetPackaeById")]
        public IHttpActionResult GetPackaeById(int packageid)
        {
            using (GalmApp.Api.Models.GalmAppDBEntities dbContext = new Models.GalmAppDBEntities())
            {
                var data = dbContext.Packages.Where(st => st.PackageId == packageid).FirstOrDefault();
                AutoMapper.Mapper.CreateMap<Package, PackageViewModel>();
                var book = AutoMapper.Mapper.Map<PackageViewModel>(data);
                return Ok(book);
            }
        }
        #endregion
    }
}
