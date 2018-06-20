namespace Study.Api.Controllers.v1
{
    using System;
    using System.Net;
    using System.Web.Http;
    using Study.Api.Requests.v1;

    public class AbstractController : ApiController
    {
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

        protected IHttpActionResult Error(Exception exception) => exception is RequestInvalidException ? Json(((RequestInvalidException)exception).Errors, HttpStatusCode.BadRequest) : StatusCode(HttpStatusCode.InternalServerError);

        protected IHttpActionResult Json<T>(T source, HttpStatusCode statusCode)
        {
            ActionContext.Response.StatusCode = statusCode;

            return Json(source);
        }
    }
}
