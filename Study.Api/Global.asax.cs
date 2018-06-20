namespace Study.Api
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Http;
    using Study.Common.Database.Repositories;
    using Study.Common.Database;
    using Study.Api.Database;
    using NHibernate;
    using System.Configuration;
    using FluentNHibernate.Cfg;
    using Study.Common.Database.Entities;
    using FluentNHibernate.Cfg.Db;

    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            SessionManager.AddProvider<Schema.Main>(BuildSessionFactory(ConfigurationManager.ConnectionStrings["Main"].ConnectionString));

            RepositoryResolver.AddTransient<IChatRepository, ChatRepository>();
        }

        private ISessionFactory BuildSessionFactory(string connectionString) => Fluently.Configure().Mappings(x => x.FluentMappings.AddFromAssemblyOf<Chat>()).Database(() => MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)).BuildSessionFactory();
    }
}
