using AppointmentManagement.Business.Abstract;
using AppointmentManagement.UI.DTOs;
using AppointmentManagement.UI.Entity.Abstract;
using AppointmentManagement.UI.Identity.Context;
using AppointmentManagement.UI.Models;
using AppointmentManagement.UI.TagHelpers.TagHelperEntity;
using AutoMapper;
using CivilManagement.UI.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Web.LayoutRenderers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivilManagement.UI.Controllers
{
    [Authorize(Roles = "Secretary")]
    public class HomeController : Controller
    {
        private readonly AppIdentityDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITrOrderAsnHeaderService _trOrderAsnHeaderService;
        private readonly IMapper _mapper;
        private readonly IAppointment _appointment;

        public HomeController(UserManager<AppUser> userManager, ITrOrderAsnHeaderService trOrderAsnHeaderService, AppIdentityDbContext context, IMapper mapper, IAppointment appointment)
        {
            _userManager = userManager;
            _trOrderAsnHeaderService = trOrderAsnHeaderService;
            _context = context;
            _mapper = mapper;
            _appointment = appointment;
        }

        public async Task<IActionResult> Index()
        {
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var orderHeaders =await _trOrderAsnHeaderService.GetWithCategoryNameAllAsync();

            SecretaryViewModel secretaryViewModel = new SecretaryViewModel
            {
                VehicleTypes = _context.VehicleTypes.ToList(),
                UserId = user.Id,
                ArticulatedLorry = orderHeaders.Where(w => w.ContainerTypeCode == "1").Select(n => new CustomSelectItem
                {
                    Value = n.OrderAsnHeaderID.ToString(),
                    Text = n.OrderAsnNumber + " " + n.CurrAccDescription,
                    Group = n.ContainerTypeDescription,
                    VehicleId = n.ContainerTypeCode,
                    VendorCode = n.CurrAccCode,
                    TotalBox = n.TotalPackage,
                    TotalPallet = n.TotalCHW
                }).ToList(),
                Truck = orderHeaders.Where(w => w.ContainerTypeCode == "2").Select(n => new CustomSelectItem
                {
                    Value = n.OrderAsnHeaderID.ToString(),
                    Text = n.OrderAsnNumber + " " + n.CurrAccDescription,
                    Group = n.ContainerTypeDescription,
                    VehicleId = n.ContainerTypeCode,
                    VendorCode = n.CurrAccCode,
                    TotalBox = n.TotalPackage,
                    TotalPallet = n.TotalCHW
                }).ToList(),
                Van = orderHeaders.Where(w => w.ContainerTypeCode == "3").Select(n => new CustomSelectItem
                {
                    Value = n.OrderAsnHeaderID.ToString(),
                    Text = n.OrderAsnNumber + " " + n.CurrAccDescription,
                    Group = n.ContainerTypeDescription,
                    VehicleId = n.ContainerTypeCode,
                    VendorCode = n.CurrAccCode,
                    TotalBox = n.TotalPackage,
                    TotalPallet = n.TotalCHW
                }).ToList(),
                DeliveryVan = orderHeaders.Where(w => w.ContainerTypeCode == "4").Select(n => new CustomSelectItem
                {
                    Value = n.OrderAsnHeaderID.ToString(),
                    Text = n.OrderAsnNumber + " " + n.CurrAccDescription,
                    Group = n.ContainerTypeDescription,
                    VehicleId = n.ContainerTypeCode,
                    VendorCode = n.CurrAccCode,
                    TotalBox = n.TotalPackage,
                    TotalPallet = n.TotalCHW
                }).ToList(),
                Car = orderHeaders.Where(w => w.ContainerTypeCode == "5").Select(n => new CustomSelectItem
                {
                    Value = n.OrderAsnHeaderID.ToString(),
                    Text = n.OrderAsnNumber + " " + n.CurrAccDescription,
                    Group = n.ContainerTypeDescription,
                    VehicleId = n.ContainerTypeCode,
                    VendorCode = n.CurrAccCode,
                    TotalBox = n.TotalPackage,
                    TotalPallet = n.TotalCHW
                }).ToList()
            };

            //OrderAsnHeadersList = orderHeaders.Select(n => new SelectListItem
            //{
            //    Value = n.OrderAsnHeaderID.ToString() + "&" + n.ContainerTypeCode,
            //    Text = n.OrderAsnNumber + " " + n.CurrAccDescription
            //      ,
            //    Group = new SelectListGroup { Name = n.ContainerTypeDescription }

            //}).ToList()

            return View(secretaryViewModel);
        }

        public async Task<IActionResult> ExpectantPlugs()
        {

            var orderHeaders = await _trOrderAsnHeaderService.GetWithCategoryNameAllAsync();
            var orders = orderHeaders.OrderBy(o => o.OrderAsnDate).ThenBy(t => t.OrderAsnNumber).ToList();

            return View(_mapper.Map<List<OrderHeaderInfoDto>>(orders));
        }

        public async Task<IActionResult> ApprovedPlugs()
        {
            var model = await _appointment.GetApprovedPlugs();
            
            return View(model.OrderBy(o => o.StartDate));
        } 

        public IActionResult test()
        {
            return View();
        }



    }
}