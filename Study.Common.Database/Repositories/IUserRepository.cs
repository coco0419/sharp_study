namespace Study.Common.Database.Repositories
{
    using Study.Common.Database.Entities;

    public interface IUserRepository : IRepository<User>
    {
        User FindByLoginId(string loginId);
    }
}
