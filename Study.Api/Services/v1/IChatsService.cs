namespace Study.Api.Services.v1
{
    using Study.Api.Requests.v1;
    using Study.Api.Responses.v1;
    using Study.Common.Database.Entities;
    using System.Collections.Generic;

    public interface IChatsService
    {
        IEnumerable<ChatsListResponse> List();
        Chat Create(ChatsCreateRequest request, long? userId);
    }
}
