using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.Entities.Concrete.FromSqlRaw;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.DataAccess.Concrete
{
    public class EfTrOrderAsnHeaderDal:EfEntityRepository<trOrderAsnHeader>,ITrOrderAsnHeaderDal
    {
        private EfCivilContext _efCivilContext { get => _context as EfCivilContext; }

        public EfTrOrderAsnHeaderDal(EfCivilContext context):base(context)
        {

        }

        public async Task<IList<OrderHeaderInfo>> GetWithCategoryNameAllAsync(string query)
        {
            return await _efCivilContext.OrderHeaderInfo.FromSqlRaw(query).ToListAsync();
        }

    
    }
}
