namespace Study.Api.Http.Results
{
    using Newtonsoft.Json;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Results;

    public class StatusCodeWithJsonResult<T> : JsonResult<T>
    {
        private readonly HttpStatusCode _statusCode;

        public StatusCodeWithJsonResult(T content, HttpStatusCode statusCode, JsonSerializerSettings serializerSettings, Encoding encoding, ApiController controller) : base(content, serializerSettings, encoding, controller) => _statusCode = statusCode;

        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var httpResponseMessage = await base.ExecuteAsync(cancellationToken);
            httpResponseMessage.StatusCode = _statusCode;

            return httpResponseMessage;
        }
    }
}