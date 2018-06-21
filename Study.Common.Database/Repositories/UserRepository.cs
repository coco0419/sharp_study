namespace Study.Common.Database.Repositories
{
    using NHibernate;
    using Study.Common.Database.Entities;

    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session) { }

        public User FindByLoginId(string loginId) => Session.QueryOver<User>().Where(x => x.LoginId == loginId).SingleOrDefault();
    }
}
