using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adv.Domain.NHibernate;

namespace AdventureWorks.Models
{
    public class ProductsIndexModel
    {
        public virtual List<Product> Products { get; set; }

        public virtual int? PageNumber { get; set; }

        public virtual int? PageSize { get; set; }

        public virtual int? TotalPages { get; set; }

        public virtual ProductModel ProductModel { get; set; }

        public virtual ProductSubCategory ProductSubCategory { get; set;}

        public virtual UnitMeasure ProductUOM { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

    }
}