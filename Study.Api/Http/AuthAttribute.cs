namespace Study.Api.Http
{
    using Study.Api.Database;
    using Study.Common.Database;
    using Study.Common.Database.Repositories;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            var authorization = actionContext.Request.Headers.GetValues("Authorization").FirstOrDefault();

            if (authorization != null)
            {
                var identity = SessionManager.Provider<Schema.Main>().OpenAndSelect(session =>
                {
                    var token = RepositoryResolver.Resolve<ITokenRepository>(session).UsingAndSelect(repository => repository.FindByValueAndUpdate(authorization));

                    return token?.Payload();
                });
                
                if (identity != null)
                {
                    HttpContext.Current.Items["__current_user__"] = identity;

                    return;
                }
            }

            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}