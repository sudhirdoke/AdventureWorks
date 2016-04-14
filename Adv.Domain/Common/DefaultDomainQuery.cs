using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;

namespace Adv.Domain.Common
{
    public class DefaultDomainQuery<T> : QueryOver<T, T>
    {
        //internal protected QueryOver<T> DefaultQueryOver { get; set; }


        //public DefaultDomainQuery()
        //{
        //    DefaultQueryOver = NHibernate.Criterion.QueryOver.Of<T>();
        //}
        public virtual IQueryOver<T, T> QueryOver(IQueryOver<T, T> query)
        {
            
            return QueryOver(query);
        }

        private QueryOver<T, T> QueryOver(QueryOver<T, T> query)
        {
            return Of<T>();
        }

    }
}
