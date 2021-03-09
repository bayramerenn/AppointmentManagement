using AppointmentManagement.Entities.Concrete.Procedure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentManagement.Business.Abstract.Procedure
{
    public interface IDataService
    {
        IEnumerable<uspGetVendorOrders> GetVendorOrders(string vendorCode, string warehoseCode);

        IEnumerable<uspGetVendorOrderLine> GetVendorOrderLine(string vendorCode, string warehoseCode);
   
        uspGetOrderAsn uspGetOrderAsnToOrderHeaderId(string orderHeaderId);

        IEnumerable<uspGetOrderAsnLineToOrderHeaderId> GetOrderAsnLineToHeaderId(string orderAsnHeaderId);

        Guid CreateOrderAsnHeader(uspCreateOrderAsnHeader entity);

        bool CreateOrderAsnLine(uspCreateOrderAsnHeader entity, Guid orderHeaderId);
        Task<bool> AddOrderAsnLine(uspCreateOrderAsnLine entity);

        IEnumerable<uspGetOrderAsn> GetOrderAsn(string vendorCode, bool isConfirmed);

        IEnumerable<uspGetOrderAsnLine> GetOrderAsnLine(string orderHeaderId);

        Task<bool> DeleteOrderAsn(string id);

        Task<bool> DeleteOrderAsnLine(string orderAsnHeaderId);

        Task<bool> UpdateOrderAsnLine(string orderAsnHeaderId, int qty);
        Task<bool> UpdateOrderAsnHeader(string orderAsnHeaderId, string containerTypeCode, int totalPackage, double totalCHW);
    }
}