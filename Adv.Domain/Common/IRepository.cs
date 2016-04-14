using Adv.Domain.Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Adv.Domain.Common
{
    public interface IRepository
    {

        void Save<T>(T obj);
        void Delete<T>(T obj);
        T GetById<T>(int id);

        IQueryable<TEntity> ToList<TEntity>() where TEntity :class;

        PagedResult<T> GetPagedList<T>(int? pageNumber, int? pageSize) where T : class;
       // IList<T> FindByQuery<T>(Expression<Func<T, bool>> predicate) where T : class;

       IList<T> FindByQuery<T>(DefaultDomainQuery<T> query) where T : class;
    }
}
