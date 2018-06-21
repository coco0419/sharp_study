namespace Study.Api.Controllers.v1
{
    using System;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Http;
    using Newtonsoft.Json;
    using Study.Api.Http.Results;
    using Study.Api.Requests.v1;
    using Study.Common.Database.Entities;

    public class AbstractController : ApiController
    {
        protected User CurrentUser => HttpContext.Current.Items["__current_user__"] as User;

        protected IHttpActionResult Try<T>(Func<T> action, Func<T, IHttpActionResult> successAction, Func<Exception, IHttpActionResult> failAction)
        {
            try
            {
                return successAction.Invoke(action.Invoke());
            }
            catch (Exception e)
            {
                return failAction.Invoke(e);
            }
        }

        protected IHttpActionResult Error(Exception exception)
        {
            if (exception is RequestInvalidException)
            {
                return Json(((RequestInvalidException)exception).Errors, HttpStatusCode.BadRequest);
            }

            throw exception;
        }

        protected IHttpActionResult Json<T>(T source, HttpStatusCode statusCode) => new StatusCodeWithJsonResult<T>(source, statusCode, new JsonSerializerSettings(), new UTF8Encoding(false, true), this);
    }
}
