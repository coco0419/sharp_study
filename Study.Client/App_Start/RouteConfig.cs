namespace Study.Client
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute("Index", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("SignIn", "signin", new { controller = "SignIn", action = "Index" });
        }
    }
}
