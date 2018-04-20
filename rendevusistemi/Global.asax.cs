using rendevusistemi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace rendevusistemi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            using (MyDbContext db = new MyDbContext())
            {

                db.Database.CreateIfNotExists();
            }
<<<<<<< HEAD
            AreaRegistration.RegisterAllAreas();
=======
         
                AreaRegistration.RegisterAllAreas();
>>>>>>> 139ac4849f8354f7997c9c933c31f89a6ddf9702
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
