using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;

namespace AdventureWorks
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Adv.Domain.NHibernate.NHibernateSession.OpenSession(HttpContext.Current);
            //Adv.Domain.Common.NHibernateRepository.OpenSession(HttpContext.Current);
        }

        protected void Application_End()
        {
            //Adv.Domain.NHibernate.NHibernateSession.CloseSession();
            Adv.Domain.NHibernate.NHibernateSession.CloseSession();
        }
    }
}
