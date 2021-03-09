using AppointmentManagement.Business.Abstract;
using AppointmentManagement.DataAccess.UnitOfWork;
using AppointmentManagement.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentManagement.Business.Concrete
{
    public class EfOrderWarehouseService : IOrderWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EfOrderWarehouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<OrderWarehouse> GetOrderWarehouses()
        {
            return _unitOfWork.OrderWarehouse.GetAllAsync().Result.ToList();

        }
    }
}