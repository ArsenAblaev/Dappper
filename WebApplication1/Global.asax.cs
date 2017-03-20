using System;
using System.Web.Http;
using WebApplication1.Configs;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute("MyRoute", "{controller}");
            AutofacConfig.Configure();
        }
    }
}