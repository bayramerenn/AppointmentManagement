using AppointmentManagement.Entities.Concrete.FromSqlRaw;
using AppointmentManagement.Entities.Concrete.Procedure;
using AppointmentManagement.UI.DTOs;
using AutoMapper;
using CivilManagement.UI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AppointmentManagement.UI.Controllers.VendorController;

namespace AppointmentManagement.UI.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserEditDto>().ReverseMap();
            CreateMap<uspGetVendorOrders, OrdersDto>().ReverseMap();
            CreateMap<uspCreateOrderAsnHeader, OrderAsn>().ReverseMap();
            CreateMap<uspCreateOrderAsnLine, OrderAsnLine>().ReverseMap();
            CreateMap<uspGetOrderAsn, OrderAsnDto>().ReverseMap();
            CreateMap<OrderHeaderInfo, OrderHeaderInfoDto>().ReverseMap();
          
        }
    }
}
