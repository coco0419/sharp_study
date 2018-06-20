namespace Study.Api.Controllers.v1
{
    using System.Web.Http;
    using Study.Api.Requests.v1;
    using Study.Api.Services.v1;

    [RoutePrefix("api/v1/chats")]
    public class ChatsController : AbstractController
    {
        private readonly IChatsService _chatsService;

        [Route]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ChatsCreateRequest request) => Try(() => _chatsService.Create(request), Json, Error);
    }
}
