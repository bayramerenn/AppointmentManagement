using AppointmentManagement.Business.Abstract;
using AppointmentManagement.DataAccess.UnitOfWork;
using AppointmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Business.Concrete
{
    public class EfVehicleServiceService : IVehicleServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EfVehicleServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<VehicleTypes> GetVehicleTypes()
        {
            return _unitOfWork.VehicleTypes.GetVehicleTypes();
        }
    }
}
