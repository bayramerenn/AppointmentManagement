using AppointmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentManagement.DataAccess.Abstract
{
    public interface IVehicleTypesDal
    {
        IQueryable<VehicleTypes> GetVehicleTypes();
    }
}
