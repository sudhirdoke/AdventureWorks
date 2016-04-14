using NHibernate;
using NHibernate.Cfg;
using System.Web;
using Adv.Domain.Common;

namespace Adv.Domain.NHibernate
{
    public class NHibernateSession
    {
        private static ISession _currentSession;
        private static NHibernateRepository _repository;
        private NHibernateSession()
        {

        }
        public static void OpenSession(HttpContext currentContext)
        {
            var configuration = new Configuration();
            var configurationPath = currentContext.Server.MapPath(@"~\Nhibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            //var prodConfigurationFile = currentContext.Server.MapPath(@"~\Nhibernate\Product.hbm.xml");
            configuration.AddFile(currentContext.Server.MapPath(@"~\Nhibernate\Product.hbm.xml"));
            configuration.AddFile(currentContext.Server.MapPath(@"~\Nhibernate\ProductCategory.hbm.xml"));
            configuration.AddFile(currentContext.Server.MapPath(@"~\Nhibernate\ProductSubCategory.hbm.xml"));
            configuration.AddFile(currentContext.Server.MapPath(@"~\Nhibernate\ProductModel.hbm.xml"));
            configuration.AddFile(currentContext.Server.MapPath(@"~\Nhibernate\UnitMeasure.hbm.xml"));

            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            _currentSession = sessionFactory.OpenSession();
            _repository = new NHibernateRepository(_currentSession);
        }

        public static void CloseSession()
        {
            _currentSession.Dispose();
        }

        public static IRepository Repository
        {
            get { return _repository; }
        }
    }
}
