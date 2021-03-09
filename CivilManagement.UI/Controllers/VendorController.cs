using AppointmentManagement.Business.Abstract;
using AppointmentManagement.Business.Abstract.Procedure;
using AppointmentManagement.DataAccess.UnitOfWork;
using AppointmentManagement.Entities.Concrete.Procedure;
using AppointmentManagement.UI.DTOs;
using AppointmentManagement.UI.Entity.Abstract;
using AppointmentManagement.UI.Models;
using AutoMapper;
using CivilManagement.UI.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Controllers
{
    [Authorize(Roles = "Vendor")]
    public class VendorController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IVehicleServiceService _vehicleService;
        private readonly IOrderWarehouseService _orderWarehouseService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        private readonly IAppointment _appointment;


        public VendorController(IDataService dataService, IMapper mapper, UserManager<AppUser> userManager, IVehicleServiceService vehicleService, IUnitOfWork unitOfWork, IOrderWarehouseService orderWarehouseService, IAppointment appointment)
        {
            _dataService = dataService;
            _mapper = mapper;
            _userManager = userManager;
            _vehicleService = vehicleService;
            _unitOfWork = unitOfWork;
            _orderWarehouseService = orderWarehouseService;
            _appointment = appointment;
        }

        public IActionResult Test1()
        {
            return View();
        }
        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var data = _mapper.Map<List<OrdersDto>>(_dataService.GetVendorOrders(user.VendorCode, ""));

            ViewData["items"] = data.Select(x => new SelectListItem() { Text = x.WarehouseDescription, Value = x.WarehouseDescription }).ToList();

            return View(data);
        }

        public IActionResult CreateAsn()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var vehicles = _vehicleService.GetVehicleTypes();
            var orderWarehouses = _orderWarehouseService.GetOrderWarehouses();

            //TempData["User"] = _userManager.FindByNameAsync(User.Identity.Name).Result;
            TempData["VendorCode"] = user.VendorCode;

            var createAsnViewModel = new CreateAsnViewModel
            {
                OrderWarehouses = new SelectList(orderWarehouses, "WarehouseCode", "WarehouseDesc"),
                Vehicle = new SelectList(vehicles, "Id", "VehicleTypeDesc"),
                OrderAsn = _dataService.GetOrderAsn(user.VendorCode, false).OrderBy(o => o.OrderAsnNumber)

            };

            return View(createAsnViewModel);
        }
        public IActionResult UpdateAsn(string id)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;


            TempData["OrderAsnHeaderId"] = user.VendorCode;

            //Araç tiplerini çekiyoruz
            var vehicles = _vehicleService.GetVehicleTypes();

            //Depolar
            var orderWarehouses = _orderWarehouseService.GetOrderWarehouses();

            //we pull the data
            var data = _dataService.uspGetOrderAsnToOrderHeaderId(id);

            //Datada kayıtlı araç tipini alıyorum
            var vehicleId = vehicles.Where(x => x.VehicleTypeDesc == data.ContainerTypeDescription).Select(s => s.Id).FirstOrDefault();

            //Asn eklenmemiş beklemede olan siparişler
            var getOrderAsnLineToHeaderId = _dataService.GetOrderAsnLineToHeaderId(id).ToList();
            var getVendorOrderLine = _dataService.GetVendorOrderLine(user.VendorCode, data.WarehouseCode).ToList();

            var OrderLineIds = getOrderAsnLineToHeaderId.Select(s => s.OrderLineID).ToArray();

            var updateAsnViewModel = new UpdateAsnViewModel
            {
                Vehicle = new SelectList(vehicles, "Id", "VehicleTypeDesc", vehicleId),
                OrderWarehouses = new SelectList(orderWarehouses, "WarehouseCode", "WarehouseDesc", data.WarehouseCode),
                TotalPackage = data.TotalPackage,
                TotalCHW = (int)data.TotalCHW,
                OrderAsnLine = getOrderAsnLineToHeaderId,
                VendorOrderLine = getVendorOrderLine.Where(w => !OrderLineIds.Contains(w.OrderLineID)),
                OrderAsnHeaderId = id
            };

            return View(updateAsnViewModel);
        }

        //[HttpPost]
        //public IActionResult UpdateAsn(UpdateAsnViewModel updateAsnViewModel)
        //{
        //    var result = _dataService.UpdateOrderAsnHeader(updateAsnViewModel.OrderAsnHeaderId, updateAsnViewModel.VehicleTypes.Id, updateAsnViewModel.TotalPackage, updateAsnViewModel.TotalCHW).Result;


        //    // Verileri tekrar yolluyorum
        //    var vehicles = _vehicleService.GetVehicleTypes();


        //    updateAsnViewModel.OrderAsnLine = _dataService.GetOrderAsnLineToHeaderId(updateAsnViewModel.OrderAsnHeaderId);
        //    updateAsnViewModel.Vehicle = new SelectList(vehicles, "Id", "VehicleTypeDesc", updateAsnViewModel.VehicleTypes.Id);


        //    //



        //    if (result)
        //    {
        //        ViewBag.Status = true;
        //        return View(updateAsnViewModel);
        //    }

        //    ViewBag.Status = false;
        //    return View(updateAsnViewModel);

        //}

        public IActionResult UpdateAsnHeader([FromBody] UpdateOrderAsnHeader updateOrderAsnHeader)
        {

            var result = _dataService.UpdateOrderAsnHeader(updateOrderAsnHeader.OrderAsnHeaderId, updateOrderAsnHeader.ContainetTypeCode, updateOrderAsnHeader.TotalPackage, updateOrderAsnHeader.TotalCHW).Result;

            if (result)
            {
                return Json("200");
            }
            return BadRequest();


        }


        public IActionResult DeleteAsn(string id)
        {

            var result = _dataService.DeleteOrderAsn(id).Result;

            if (result)
            {
                return StatusCode(200);
            }
            return BadRequest();
        }


        public IActionResult GetVendorOrders([FromBody] Warehouse warehouse)
        {

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var data = _dataService.GetVendorOrderLine(user.VendorCode, warehouse.WarehouseCode);

            return Json(data);
        }
        public IActionResult CreateOrderAsn([FromBody] OrderAsn orderAsn)
        {
            var model = _mapper.Map<uspCreateOrderAsnHeader>(orderAsn);

            var orderHeaderId = _dataService.CreateOrderAsnHeader(model);

            if (orderHeaderId.ToString() != "00000000-0000-0000-0000-000000000000")
            {
                var result = _dataService.CreateOrderAsnLine(model, orderHeaderId);

                if (result)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }

        public IActionResult AddOrderAsnLine([FromBody] OrderAsnLine orderAsnLine)
        {
            var data = _mapper.Map<uspCreateOrderAsnLine>(orderAsnLine);
            var result = _dataService.AddOrderAsnLine(data).Result;
            if (result)
            {
                return Json("200");
            }

            return BadRequest();
        }
        public IActionResult GetOrderAsnLine(string id)
        {
            var model = _dataService.GetOrderAsnLine(id).ToList();

            return Json(model);
        }

        public IActionResult UpdateOrderAsnLine(string id, string qty)
        {
            var result = _dataService.UpdateOrderAsnLine(id, int.Parse(qty)).Result;
            if (result)
            {
                return Json("200");
            }

            return BadRequest();

        }

        public IActionResult DeleteOrderAsnLine(string orderAsnLineId)
        {
            var result = _dataService.DeleteOrderAsnLine(orderAsnLineId).Result;
            if (result)
            {
                return Json("200");
            }

            return BadRequest();

        }

        public async Task<IActionResult> ApprovedPlugs()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            var model = await _appointment.GetApprovedPlugsByVendorCode(user.VendorCode);

            return View(model.OrderBy(o => o.StartDate));

        }

        public class OrderHeader
        {
            public string OrderAsnHeaderID { get; set; }
        }
        public class Warehouse
        {
            public string WarehouseCode { get; set; }
        }
        public class OrderAsn
        {
            public Guid OrderAsnHeaderID { get; set; }
            public string ContainerTypeCode { get; set; }
            public int BoxQuantity { get; set; }
            public int PalletQuantity { get; set; }
            public string VendorCode { get; set; }
            public string WarehouseCode { get; set; }
            public List<OrderAsnLine> OrderAsnLines { get; set; }
        }
        public class OrderAsnLine
        {
            public string OrderAsnHeaderId { get; set; }
            public string ItemCode { get; set; }
            public string ColorCode { get; set; }
            public string ItemDim1Code { get; set; }
            public int Qty1 { get; set; }
            public string ItemTypeCode { get; set; }
            public Guid OrderLineID { get; set; }
            public DateTime DeliveryDate { get; set; }

        }

        public class UpdateOrderAsnHeader
        {
            public string ContainetTypeCode { get; set; }
            public string OrderAsnHeaderId { get; set; }
            public int TotalPackage { get; set; }
            public int TotalCHW { get; set; }
        }
    }
}