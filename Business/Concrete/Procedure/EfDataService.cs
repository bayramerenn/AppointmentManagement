using AppointmentManagement.Business.Abstract.Procedure;
using AppointmentManagement.DataAccess.UnitOfWork;
using AppointmentManagement.Entities.Concrete.Procedure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog.Web.LayoutRenderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppointmentManagement.Business.Concrete.Procedure
{
    public class EfDataService : IDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EfDataService> _logger;

        public EfDataService(IUnitOfWork unitOfWork, ILogger<EfDataService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> AddOrderAsnLine(uspCreateOrderAsnLine entity)
        {
            bool result = true;
            try
            {
               await _unitOfWork.DataProcedure.AddOrderAsnLine(entity);
            }
            catch (Exception ex)
            {

                result = false;
                var httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.User.Identity.Name;
                _logger.LogError(ex, user + " tarafından hata oluştu"); 

            }
            return result;
       }

        public Guid CreateOrderAsnHeader(uspCreateOrderAsnHeader entity)
        {

            Guid orderHeaderId = new Guid();
            try
            {
                orderHeaderId = _unitOfWork.DataProcedure.CreateOrderAsnHeader(entity);
            }
            catch (Exception ex)
            {

                var httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.User.Identity.Name;
                _logger.LogError(ex, user + " tarafından hata oluştu");

            }
            return orderHeaderId;
        }

        public bool CreateOrderAsnLine(uspCreateOrderAsnHeader entity, Guid orderHeaderId)
        {
            bool result = true;
            try
            {
                
                _unitOfWork.DataProcedure.CreateOrderAsnLine(entity, orderHeaderId).Wait();
            }
            catch (Exception ex)
            {
                result = false;
                var httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.User.Identity.Name;
                _logger.LogError(ex, user + " tarafından hata oluştu");
            }

            return result;
        }

        public async Task<bool> DeleteOrderAsn(string id)
        {
            var result = true;
            try
            {
                await _unitOfWork.DataProcedure.DeleteOrderAsn(id);
            }
            catch (Exception ex)
            {
                result = false;
                var httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.User.Identity.Name;
                _logger.LogError(ex, user + " tarafından hata oluştu");
            }

            return result;
        }

        public async Task<bool> DeleteOrderAsnLine(string orderAsnHeaderId)
        {
            bool result = true;
            try
            {
                await _unitOfWork.DataProcedure.DeleteOrderAsnLine(orderAsnHeaderId);
            }
            catch (Exception ex)
            {
                result = false;
                var httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.User.Identity.Name;
                _logger.LogError(ex, user + " tarafından hata oluştu");
            }
            return result;
        }

        public IEnumerable<uspGetOrderAsn> GetOrderAsn(string vendorCode, bool isConfirmed)
        {
            return _unitOfWork.DataProcedure.GetOrderAsn(vendorCode, isConfirmed);
        }

        public IEnumerable<uspGetOrderAsnLine> GetOrderAsnLine(string orderHeaderId)
        {
            return _unitOfWork.DataProcedure.GetOrderAsnLine(orderHeaderId);
        }

        public IEnumerable<uspGetOrderAsnLineToOrderHeaderId> GetOrderAsnLineToHeaderId(string orderAsnHeaderId)
        {
            return _unitOfWork.DataProcedure.GetOrderAsnLineToHeaderId(orderAsnHeaderId);
        }

        public IEnumerable<uspGetVendorOrderLine> GetVendorOrderLine(string vendorCode, string warehoseCode)
        {
            return _unitOfWork.DataProcedure.GetVendorOrderLine(vendorCode, warehoseCode).ToList();
        }

        public IEnumerable<uspGetVendorOrders> GetVendorOrders(string vendorCode, string warehoseCode)
        {
            return _unitOfWork.DataProcedure.GetVendorOrders(vendorCode, warehoseCode).ToList();
        }

     

        public async Task<bool> UpdateOrderAsnHeader(string orderAsnHeaderId, string containerTypeCode, int totalPackage, double totalCHW)
        {
            bool result = true;
            try
            {
                await _unitOfWork.DataProcedure.UpdateOrderAsnHeader(orderAsnHeaderId, containerTypeCode, totalPackage, totalCHW);
            }
            catch (Exception ex)
            {

                result = false;
                var httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.User.Identity.Name;
                _logger.LogError(ex, user + " tarafından hata oluştu");
            }

            return result;
        }

        public async Task<bool> UpdateOrderAsnLine(string orderAsnHeaderId, int qty)
        {
            bool result = true;
            try
            {
                await _unitOfWork.DataProcedure.UpdateOrderAsnLine(orderAsnHeaderId, qty);
            }
            catch (Exception ex)
            {
                result = false;
                var httpContextAccessor = new HttpContextAccessor();
                var user = httpContextAccessor.HttpContext.User.Identity.Name;
                _logger.LogError(ex, user + " tarafından hata oluştu");
            }
            return result;
        }

        public uspGetOrderAsn uspGetOrderAsnToOrderHeaderId(string orderHeaderId)
        {
            return _unitOfWork.DataProcedure.GetOrderAsnToOrderHeaderId(orderHeaderId);
        }
    }
}