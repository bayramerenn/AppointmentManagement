using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.DataAccess.Concrete
{
    public class EfOrderWarehouseDal:EfEntityRepository<OrderWarehouse>,IOrderWarehouseDal
    {
       
        
        public EfCivilContext _appDbContext { get => _context as EfCivilContext; }
        public EfOrderWarehouseDal(EfCivilContext context):base(context)
        {
        }
    }
}
