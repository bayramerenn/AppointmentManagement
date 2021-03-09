using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentManagement.DataAccess.Concrete
{
    public class EfVehicleTypesDal : IVehicleTypesDal
    {
        private readonly EfCivilContext _efCivilContext;

        public EfVehicleTypesDal(EfCivilContext efCivilContext)
        {
            _efCivilContext = efCivilContext;
        }

        public IQueryable<VehicleTypes> GetVehicleTypes()
        {
            return _efCivilContext.VehicleTypes.FromSqlRaw("SELECT Id = ContainerTypeCode,VehicleTypeDesc = ContainerTypeDescription FROM dbo.cdContainerTypeDesc");
        }
    }
}
