using Adv.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adv.Domain.NHibernate
{
   public class ProductModel : DefaultDomainEntity
    {
        public virtual string ProductModelName { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
