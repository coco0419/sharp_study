namespace Study.Common.Database.Repositories
{
    using NHibernate;

    public abstract class AbstractRepository<T> : IRepository<T>
    {
        private readonly ISession _session;

        public AbstractRepository(ISession session) => _session = session;

        public object Create(T source) => _session.Save(source);

        public void Dispose()
        {
            _session.Flush();
        }
    }
}
