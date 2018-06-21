namespace Study.Api.Controllers.v1
{
    using System.Web.Http;
    using Study.Api.Http;
    using Study.Api.Requests.v1;
    using Study.Api.Services.v1;

    [Auth]
    [RoutePrefix("api/v1/chats")]
    public class ChatsController : AbstractController
    {
        private readonly IChatsService _chatsService;

        public ChatsController() : this(new ChatsService()) { }

        public ChatsController(IChatsService chatsService) => _chatsService = chatsService;

        [Route]
        [HttpGet]
        public IHttpActionResult List() => Try(() => _chatsService.List(), Json, Error);

        [Route]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ChatsCreateRequest request) => Try(() => _chatsService.Create(request, CurrentUser.Id), Json, Error);
    }
}
