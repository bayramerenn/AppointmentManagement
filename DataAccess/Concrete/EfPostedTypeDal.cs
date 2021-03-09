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
    public class EfPostedTypeDal : IPostedTypeDal
    {

        private readonly EfCivilContext _efCivilContext;

        public EfPostedTypeDal(EfCivilContext efCivilContext)
        {
            _efCivilContext = efCivilContext;
        }

        public IQueryable<PostedType> GetPostedTypes()
        {
            return _efCivilContext.PostedTypes.FromSqlRaw("SELECT Id = AttributeCode,PostedTypeDesc = AttributeDescription FROM dbo.cdITAttributeDesc WHERE AttributeTypeCode=1");
        }
    }
}
