namespace Study.Api.Services.v1
{
    using Study.Api.Requests.v1;
    using Study.Common.Database.Entities;

    public interface IChatsService
    {
        Chat Create(ChatsCreateRequest request);
    }
}
