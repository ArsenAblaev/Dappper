using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PersonManager.Model.Repositories;
using WebApplication1.Application.Services;

namespace WebApplication1.Configs
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
            RegisterTypes(builder);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterInstance(new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                .As<IDbConnection>();
        }
    }
}