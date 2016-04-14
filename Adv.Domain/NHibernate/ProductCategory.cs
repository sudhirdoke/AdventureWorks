using Adv.Domain.Common;
using System;


namespace Adv.Domain.NHibernate
{
   public class ProductCategory : DefaultDomainEntity
    {
        
        public virtual string ProductCategoryName { get; set; }

        public virtual string rowguid { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
