using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Entities.Concrete
{
    public abstract class ModelBase
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
