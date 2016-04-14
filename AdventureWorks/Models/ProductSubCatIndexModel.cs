using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adv.Domain.NHibernate;

namespace AdventureWorks.Models
{
    public class ProductSubCatIndexModel
    {
        public virtual List<ProductSubCategory> ProductSubCategoriesList { get; set; }

    }
}