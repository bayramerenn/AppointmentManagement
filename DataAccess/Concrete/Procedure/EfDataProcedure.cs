using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.DataAccess.Abstract.Procedure;
using AppointmentManagement.Entities.Concrete.Procedure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.DataAccess.Concrete.Procedure
{
    public class EfDataProcedure : IDataProcedure
    {
        private readonly EfCivilContext _civilContext;
     

        public EfDataProcedure(EfCivilContext civilContext)
        {
            _civilContext = civilContext;
        }

        public Guid CreateOrderAsnHeader(uspCreateOrderAsnHeader entity)
        {
            var orderHeaderId = _civilContext.Set<uspCreateOrderAsnHeader>()
                    .FromSqlRaw($"EXEC dbo.uspCreateOrderAsnHeader @ContainerTypeCode = '{entity.ContainerTypeCode}'," +
                                                                 $"@BoxQuantity = {entity.BoxQuantity}," +
                                                                 $"@PalletQuantity = {entity.PalletQuantity}," +
                                                                 $"@VenderCode = '{entity.VendorCode}'," +
                                                                 $"@WarehouseCode ='{entity.WarehouseCode}' ")
                                                                 .Select(s => s.OrderAsnHeaderID).ToList();

            return orderHeaderId[0];
        }
        public async Task CreateOrderAsnLine(uspCreateOrderAsnHeader entity, Guid orderHeaderId)
        {
            try
            {
                
                foreach (var item in entity.OrderAsnLines)
                {
                   var date = item.DeliveryDate.ToString("yyyy/MM/dd");

                   await _civilContext.Database
                        .ExecuteSqlRawAsync($"EXEC dbo.uspCreateOrderAsnLine @OrderAsnHeaderID = '{orderHeaderId}',@ItemTypeCode = {item.ItemTypeCode},@ItemCode = '{item.ItemCode}',@ColorCode = '{item.ColorCode}',@ItemDim1Code ='{item.ItemDim1Code}',@Qty1 ={item.Qty1},@OrderLineID ='{item.OrderLineID}',@OrderDeliveryDate   ='{date}'");
                }
            }
            catch
            {
                await _civilContext.Database.ExecuteSqlRawAsync($" EXEC dbo.sp_DeleteOrderAsnTrans @ApplicationCode = 'Asn',@OrderAsnHeaderID = '{orderHeaderId}',@OnlyIntegratedRecords = 0");
            }

        }

        public async Task DeleteOrderAsn(string id)
        {
           await _civilContext.Database.ExecuteSqlRawAsync($" EXEC dbo.sp_DeleteOrderAsnTrans @ApplicationCode = 'Asn',@OrderAsnHeaderID = '{id}',@OnlyIntegratedRecords = 0");
        }

        public async Task DeleteOrderAsnLine(string orderAsnHeaderId)
        {
            await _civilContext.Database.ExecuteSqlRawAsync($"EXEC uspDeleteOrderAsnLine @OrderAsnLineID='{orderAsnHeaderId}'");
        }

        public IEnumerable<uspGetOrderAsn> GetOrderAsn(string vendorCode, bool isConfirmed)
        {
            return  _civilContext.Set<uspGetOrderAsn>()
                    .FromSqlRaw($"EXEC uspGetOrderAsn @VendorCode='{vendorCode}',@IsConfirmed={isConfirmed}").ToList();

             
        }

        public IEnumerable<uspGetOrderAsnLine> GetOrderAsnLine(string orderHeaderId)
        {
            return _civilContext.Set<uspGetOrderAsnLine>()
                                .FromSqlRaw($"EXEC uspGetOrderAsnLine @OrderAsnHeaderID = '{orderHeaderId}'");
        }

        public IEnumerable<uspGetOrderAsnLineToOrderHeaderId> GetOrderAsnLineToHeaderId(string orderAsnHeaderId)
        {
            return _civilContext.Set<uspGetOrderAsnLineToOrderHeaderId>()
                        .FromSqlRaw($"EXEC dbo.uspGetOrderAsnLineToOrderHeaderId @OrderHeaderId = '{orderAsnHeaderId}'").ToList();
        }

        public IQueryable<uspGetVendorOrderLine> GetVendorOrderLine(string vendorCode, string warehoseCode)
        {
            return _civilContext.Set<uspGetVendorOrderLine>().FromSqlRaw($"EXEC uspGetVendorOrderLine @VendorCode='{vendorCode}',@WarehouseCode='{warehoseCode}'");
        }

        public IEnumerable<uspGetVendorOrders> GetVendorOrders(string vendorCode, string warehoseCode)
        {
            var model = _civilContext.Set<uspGetVendorOrders>().FromSqlRaw($"EXEC uspGetVendorOrders @VendorCode='{vendorCode}',@WarehouseCode='{warehoseCode}'").ToList();

            return model;
        }

        public async Task UpdateOrderAsnLine(string orderAsnHeaderId,int qty)
        {
            await _civilContext.Database.ExecuteSqlRawAsync($"EXEC uspUpdateOrderAsnLineQty @OrderAsnLineID='{orderAsnHeaderId}',@Qty1={qty}");
        }

        public uspGetOrderAsn GetOrderAsnToOrderHeaderId(string orderHeaderId)
        {
            return _civilContext.Set<uspGetOrderAsn>()
                   .FromSqlRaw($"EXEC dbo.uspGetOrderAsnToOrderHeaderId @OrderHeaderId = '{orderHeaderId}'").ToList().FirstOrDefault();
        }

        public async Task UpdateOrderAsnHeader(string orderAsnHeaderId, string containerTypeCode, int totalPackage, double totalCHW)
        {
            await _civilContext.Database.ExecuteSqlRawAsync($"EXEC uspUpdateOrderAsnHeader @OrderAsnHeaderID='{orderAsnHeaderId}',@ContainerTypeCode='{containerTypeCode}',@TotalPackage={totalPackage},@TotalCHW={totalCHW}");
        }

        public async Task AddOrderAsnLine(uspCreateOrderAsnLine entity)
        {
            var date = entity.DeliveryDate.ToString("yyyy/MM/dd");
           await _civilContext.Database
                .ExecuteSqlRawAsync($"EXEC dbo.uspCreateOrderAsnLine @OrderAsnHeaderID = '{entity.OrderAsnHeaderID}',@ItemTypeCode = {entity.ItemTypeCode},@ItemCode = '{entity.ItemCode}',@ColorCode = '{entity.ColorCode}',@ItemDim1Code ='{entity.ItemDim1Code}',@Qty1 ={entity.Qty1},@OrderLineID ='{entity.OrderLineID}',@OrderDeliveryDate   ='{date}'");
        }
    }
}