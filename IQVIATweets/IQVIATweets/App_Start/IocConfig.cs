using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using IQVIA.Business.Interfaces;
using IQVIA.Business.Managers;

namespace IdahoStars.Services
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<TweetManager>().As<ITweetManager>();

           //Registering Generic Repository
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers
            var container = builder.Build();
                          
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}