using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adv.Domain.NHibernate;

namespace AdventureWorks.Models
{
    public class ProductCategoryIndexModel
    {
        public virtual List<ProductCategory> ProductCategoryList { get; set; }

        public virtual string ProductCategoryName { get; set; }

        public virtual string RowGUID { get; set; }

        public virtual DateTime ModifiedDate { get; set; }
    }
}