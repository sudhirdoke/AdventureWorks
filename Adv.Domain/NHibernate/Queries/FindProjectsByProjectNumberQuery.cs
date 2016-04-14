using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using Adv.Domain.Common;

namespace Adv.Domain.NHibernate.Queries
{
   public class FindProjectsByProjectNumberQuery : DefaultDomainQuery<Product>
    {
        private string _projectNumber = "";
        public FindProjectsByProjectNumberQuery(string projectNumber)
        {
            _projectNumber = projectNumber;
        }

        public override IQueryOver<Product, Product> QueryOver(IQueryOver<Product, Product> query)
        {
            return base.QueryOver(query).Where(p => p.ProductNumber == _projectNumber);
        }
    }
}
