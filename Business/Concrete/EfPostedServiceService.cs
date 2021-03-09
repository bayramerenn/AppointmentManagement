using AppointmentManagement.Business.Abstract;
using AppointmentManagement.DataAccess.UnitOfWork;
using AppointmentManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Business.Concrete
{
    public class EfPostedServiceService : IPostedServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EfPostedServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PostedType> GetPostedTypes()
        {
            return _unitOfWork.PostedType.GetPostedTypes();
        }
    }
}
