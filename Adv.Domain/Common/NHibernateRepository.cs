using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Adv.Domain.Common
{
    public class NHibernateRepository : IRepository
    {
        private ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
        }
        //private static ISession _session;
        //private NHibernateRepository()
        //{ }

        //public static void OpenSession(HttpContext currentContext)
        //{
        //    var configuration = new Configuration();
        //    var configurationPath = currentContext.Server.MapPath(@"~\Nhibernate\hibernate.cfg.xml");
        //    configuration.Configure(configurationPath);
        //    var employeeConfigurationFile = currentContext.Server.MapPath(@"~\Nhibernate\Product.hbm.xml");
        //    configuration.AddFile(employeeConfigurationFile);
        //    ISessionFactory sessionFactory = configuration.BuildSessionFactory();
        //    _session = sessionFactory.OpenSession();
        //    //_repository = new NHibernateRepository(_currentSession);
        //}

        //public static void CloseSession()
        //{
        //    _session.Dispose();
        //}

        //public T Load<T>(Guid id)
        //{
        //    return _session.Load<T>(id);
        //}

        //public T Get<T>(Guid id)
        //{
        //    return _session.Get<T>(id);
        //}

        public void Save<T>(T obj)
        {
            _session.SaveOrUpdate(obj);
        }

        public void Delete<T>(T obj)
        {
            _session.Delete(obj);
        }


        T IRepository.GetById<T>(int id)
        {
            return _session.Load<T>(id);
        }

        IQueryable<TEntity> IRepository.ToList<TEntity>()
        {
            return _session.QueryOver<TEntity>().List().AsQueryable();
        }

        PagedResult<T> IRepository.GetPagedList<T>(int? pageNumber, int? pageSize)
        {
            int p = pageNumber ?? 1;
            int s = pageSize ?? 10;
            var query = _session.QueryOver<T>().TransformUsing(Transformers.DistinctRootEntity);
            var totalCount = query.RowCount();
            var pagedList = query.Skip((p - 1) * s).Take(s).List<T>();
            

            return new PagedResult<T>(pagedList, s, totalCount);
        }
        //Get all T
        //public IEnumerable<T> Matching<T>() where T : DomainObject
        //{
        //    return _session.CreateCriteria<T>().List<T>();
        //}

        ////NHibernate 3.0 Linq
        // IList<T> IRepository.FindByQuery<T>(Expression<Func<T, bool>> predicate) 
        //{
            
        //    return _session.QueryOver<T>().Where(predicate).List();
        //}

        IList<T> IRepository.FindByQuery<T>(DefaultDomainQuery<T> query)
        {

            return query.GetExecutableQueryOver(_session).List<T>();
        }

        //public IEnumerable<T> Matching<T>(ICreateCriteria<T> query, params IAppendCriterion[] extraCriterias)
        //{
        //    var criteria = query.GetCriteria();
        //    foreach (var criterion in extraCriterias)
        //    {
        //        criterion.Append(criteria);
        //    }

        //    return criteria.GetExecutableCriteria(_session).List<T>();
        //}
    }
}
