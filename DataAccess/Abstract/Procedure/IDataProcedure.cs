using AppointmentManagement.Entities.Concrete.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.DataAccess.Abstract.Procedure
{
    public interface IDataProcedure
    {
        IEnumerable<uspGetVendorOrders> GetVendorOrders(string vendorCode, string warehoseCode);

        IQueryable<uspGetVendorOrderLine> GetVendorOrderLine(string vendorCode, string warehoseCode);

        IEnumerable<uspGetOrderAsn> GetOrderAsn(string vendorCode, bool isConfirmed);

        IEnumerable<uspGetOrderAsnLineToOrderHeaderId> GetOrderAsnLineToHeaderId(string orderAsnHeaderId);
    

        uspGetOrderAsn GetOrderAsnToOrderHeaderId(string orderHeaderId);

        IEnumerable<uspGetOrderAsnLine> GetOrderAsnLine(string orderHeaderId);

        Guid CreateOrderAsnHeader(uspCreateOrderAsnHeader entity);

        Task CreateOrderAsnLine(uspCreateOrderAsnHeader entity, Guid orderHeaderId);

        Task AddOrderAsnLine(uspCreateOrderAsnLine entity);

        Task DeleteOrderAsn(string id);

        Task DeleteOrderAsnLine(string orderAsnHeaderId);

        Task UpdateOrderAsnLine(string orderAsnHeaderId, int qty);
        Task UpdateOrderAsnHeader(string orderAsnHeaderId,string containerTypeCode,int totalPackage,double totalCHW);
    }
}