namespace Study.Api.Services.v1
{
    using System;
    using Study.Api.Database;
    using Study.Api.Requests.v1;
    using Study.Common.Database;
    using Study.Common.Database.Entities;
    using Study.Common.Database.Repositories;

    public class MessagesService : IChatsService
    {
        public Chat Create(ChatsCreateRequest request)
        {
            request.Valid();

            return SessionManager
                .Provider<Schema.Main>()
                .OpenAndSelect(session => RepositoryResolver.Resolve<IChatRepository>(session).UsingAndSelect(repository =>
                {
                    var entity = new Chat() { Message = request.Message };
                    entity.Id = repository.Create(entity) as long?;

                    return entity;
                }));
        }
    }
}
