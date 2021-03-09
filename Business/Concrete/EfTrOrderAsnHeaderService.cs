using AppointmentManagement.Business.Abstract;
using AppointmentManagement.Core.DataAccess;
using AppointmentManagement.DataAccess.UnitOfWork;
using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.Entities.Concrete.FromSqlRaw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Business.Concrete
{
    public class EfTrOrderAsnHeaderService : ITrOrderAsnHeaderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EfTrOrderAsnHeaderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<trOrderAsnHeader>> GetOrderAsnHeadersAsync(Expression<Func<trOrderAsnHeader,bool>> predicate=null)
        {
            var result = predicate == null
                        ?await _unitOfWork.trOrderAsnHeader.GetAllAsync()
                        :await _unitOfWork.trOrderAsnHeader.GetAllAsync(predicate);

            return result;
        }

        public async Task<trOrderAsnHeader> GetTrOrderAsnHeaderAsync(Guid orderAsnHeaderId)
        {
            var model =await _unitOfWork.trOrderAsnHeader.GetAllAsync(x => x.OrderAsnHeaderID == orderAsnHeaderId);

            return model.FirstOrDefault();
        }

        public async Task<IList<OrderHeaderInfo>> GetWithCategoryNameAllAsync()
        {
            var query = "SELECT OrderAsnHeaderID,OrderAsnNumber,trOrderAsnHeader.CurrAccCode,WarehouseDescription,CurrAccDescription,trOrderAsnHeader.ContainerTypeCode,ContainerTypeDescription,TotalPackage,TotalCHW,trOrderAsnHeader.OrderAsnDate FROM dbo.trOrderAsnHeader WITH(NOLOCK) JOIN dbo.cdCurrAccDesc WITH(NOLOCK) ON cdCurrAccDesc.CurrAccCode = trOrderAsnHeader.CurrAccCode  AND cdCurrAccDesc.CurrAccTypeCode = 1 AND LangCode = 'TR' JOIN cdContainerTypeDesc WITH(NOLOCK) ON cdContainerTypeDesc.ContainerTypeCode = trOrderAsnHeader.ContainerTypeCode JOIN dbo.cdWarehouseDesc WITH(NOLOCK) ON cdWarehouseDesc.WarehouseCode = trOrderAsnHeader.WarehouseCode WHERE IsCompleted = 1 AND IsConfirmed = 0";

            return await _unitOfWork.trOrderAsnHeader.GetWithCategoryNameAllAsync(query);
        }

        public void Update(trOrderAsnHeader entity)
        {
            _unitOfWork.trOrderAsnHeader.Update(entity);
            _unitOfWork.V3Commit();
        }
    }
}
