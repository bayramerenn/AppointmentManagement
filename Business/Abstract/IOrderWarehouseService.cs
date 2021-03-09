using AppointmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Business.Abstract
{
    public interface IOrderWarehouseService
    {
        List<OrderWarehouse> GetOrderWarehouses();
    }
}
