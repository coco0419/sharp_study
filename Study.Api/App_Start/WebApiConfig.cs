using System.Web.Http;

namespace Study.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config) => config.MapHttpAttributeRoutes();
    }
}
