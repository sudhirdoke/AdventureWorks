﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adv.Domain.Common;

namespace Adv.Domain.NHibernate
{
    public class Product : DefaultDomainEntity
    {
        public virtual string ProductName { get; set; }
        public virtual string ProductNumber { get; set; }
        public virtual bool MakeFlag { get; set; }
        public virtual bool FinishedGoodsFlag { get; set; }
        public virtual string Color { get; set; }
        public virtual int SafetyStockLevel { get; set; }
        public virtual int ReorderPoint { get; set; }

        public virtual decimal StandardCost { get; set; }

        public virtual decimal ListPrice { get; set; }
        public virtual string Size { get; set; }
        public virtual string SizeUnitMeasureCode { get; set; }
        public virtual string WeightUnitMeasureCode { get; set; }
        public virtual double Weight { get; set; }
        public virtual int DaysToManufacture { get; set; }
        public virtual string ProductLine { get; set; }
        public virtual string Class { get; set; }
        public virtual string Style { get; set; }
        public virtual int? ProductSubcategoryID { get; set; }
        public virtual int? ProductModelID { get; set; }
        public virtual DateTime SellStartDate { get; set; }
        public virtual DateTime SellEndDate { get; set; }
        public virtual DateTime DiscontinuedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }


}
