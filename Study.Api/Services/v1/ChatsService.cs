namespace Study.Api.Services.v1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Study.Api.Database;
    using Study.Api.Requests.v1;
    using Study.Api.Responses.v1;
    using Study.Common.Database;
    using Study.Common.Database.Entities;
    using Study.Common.Database.Repositories;

    public class ChatsService : IChatsService
    {
        public IEnumerable<ChatsListResponse> List() => SessionManager
            .Provider<Schema.Main>()
            .OpenAndSelect(session => RepositoryResolver.Resolve<IChatRepository>(session).UsingAndSelect(repository => repository.List().Select(c => new ChatsListResponse()
            {
                Chat = c,
                User = c.User
            })));

        public Chat Create(ChatsCreateRequest request, long? userId)
        {
            request.Valid();

            return SessionManager
                .Provider<Schema.Main>()
                .OpenAndSelect(session => RepositoryResolver.Resolve<IChatRepository>(session).UsingAndSelect(repository =>
                {
                    var entity = new Chat() { Message = request.Message, UserId = userId };
                    entity.Id = repository.Create(entity) as long?;

                    return entity;
                }));
        }
    }
}
