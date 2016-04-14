using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adv.Domain.NHibernate
{
    public class UnitMeasure
    {
        public virtual string UnitMeasureCode { get; set; }
        public virtual string UnitMeasureName { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
