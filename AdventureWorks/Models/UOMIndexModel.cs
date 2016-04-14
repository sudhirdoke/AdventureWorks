using Adv.Domain.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models
{
    public class UOMIndexModel
    {
        public virtual List<UnitMeasure> UnitMeasureList  { get; set;}
    }
}