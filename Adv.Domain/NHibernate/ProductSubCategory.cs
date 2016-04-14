using Adv.Domain.Common;
using System;


namespace Adv.Domain.NHibernate
{
    public class ProductSubCategory : DefaultDomainEntity
    {
        
        public virtual int ProductCategoryID { get; set; }
        public virtual string ProductSubcategoryName { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
