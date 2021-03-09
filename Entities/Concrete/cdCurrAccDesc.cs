using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Entities.Concrete
{
    public class cdCurrAccDesc
    {
        public byte CurrAccTypeCode { get; set; }
        public string CurrAccCode { get; set; }
        public string LangCode { get; set; }
        public string CurrAccDescription { get; set; }
    }
}
