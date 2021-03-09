using AppointmentManagement.Business.Abstract;
using AppointmentManagement.UI.Entity.Abstract;
using AppointmentManagement.UI.Entity.CustomEntity;
using AppointmentManagement.UI.Identity;
using AppointmentManagement.UI.Identity.Context;
using AppointmentManagement.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppIdentityDbContext _context;
        private readonly IAppointment _appointment;
        private readonly ITrOrderAsnHeaderService _trOrderAsnHeaderService;

        public AppointmentController(AppIdentityDbContext context, IAppointment appointment, ITrOrderAsnHeaderService trOrderAsnHeaderService)
        {
            _context = context;
            _appointment = appointment;
            _trOrderAsnHeaderService = trOrderAsnHeaderService;
        }

        public IActionResult GetAppointments()
        {

           List<CustomAppointment> model = _appointment.GetRegisteredAppointment().ToList();

            return Json(model);
        }

        public IActionResult GetAppointmentsByVehicle(string vehicleTypeId = "")
        {
            var model = _appointment.GetRegisteredAppointmentByVehicleTypeId(int.Parse(vehicleTypeId));

            return Json(model);
        }

        public IActionResult Test()
        {
            var x = _context.Appointments.ToList();

            return Json(x);
        }

        /// <summary>
        ///  trOrderAsnHeader IsConfirmed kolonun update işlemi
        ///  Appointment tablosunu create ve update işlemi
        /// </summary>
        /// <param name="model">Appointment bilgilerini taşır</param>
        /// <returns></returns>
        public async Task<IActionResult> AddOrUpdateAppointment([FromBody] AddOrUpdateAppointmentModel model)
        {
            if (model.Id == 0)
            {
                //OrderAsnHeader onaylanması
                var orderHeader = _trOrderAsnHeaderService.GetTrOrderAsnHeaderAsync(model.OrderAsnHeaderId).Result;
                orderHeader.IsConfirmed = true;
                _trOrderAsnHeaderService.Update(orderHeader);


                //Appointment tablosunun onaylanması
                Appointment entity = new Appointment()
                {
                    CreatedDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    StartDate = DateTime.Parse(model.StartDate),
                    EndDate = DateTime.Parse(model.EndDate),
                    OrderAsnHeaderId = model.OrderAsnHeaderId,
                    Description = model.Description,
                    VehicleTypeId = model.VehicleTypeId,
                    UserId = model.UserId,
                    VendorCode = model.VendorCode
                };

                await _appointment.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                var entity = _context.Appointments.Find(model.Id);

                if (entity == null)
                {
                    return Json("400");
                }
                entity.UpdateDate = DateTime.Now;
                entity.StartDate = DateTime.Parse(model.StartDate);
                entity.EndDate = DateTime.Parse(model.EndDate);
                entity.Description = model.Description;
                entity.OrderAsnHeaderId = model.OrderAsnHeaderId;
                entity.VendorCode = model.VendorCode;
                entity.VehicleTypeId = model.VehicleTypeId;

                _appointment.Update(entity);
                _context.SaveChanges();
            }

            return Json("200");
        }

        public JsonResult DeleteAppointment(string id)
        {
            var entity = _context.Appointments.Find(int.Parse(id));
            if (entity != null)
            {
                //OrderAsnHeader onaylanması
                var orderHeader = _trOrderAsnHeaderService.GetTrOrderAsnHeaderAsync(entity.OrderAsnHeaderId).Result;
                orderHeader.IsConfirmed = false;
                _trOrderAsnHeaderService.Update(orderHeader);

                //
                _appointment.Remove(entity);
                _context.SaveChanges();

                return Json("200");
            }

            return Json("400");
        }
    }
}