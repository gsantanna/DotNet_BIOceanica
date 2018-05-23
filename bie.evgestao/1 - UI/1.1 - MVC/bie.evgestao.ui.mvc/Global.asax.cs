using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

//bie.evgestao.ui.mvc.MvcApplication

namespace bie.evgestao.ui.mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

                AutoMapper.AutomapConfig.Configure();

            }

            public void Application_BeginRequest(object sender, EventArgs e)
            {
                SetCulture();
            }



            private void SetCulture()
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

            }







         



    }
}
