using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PersonManager.Model.Repositories;

namespace WebApplication1.Configs
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }


        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}