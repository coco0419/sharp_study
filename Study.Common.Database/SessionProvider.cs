namespace Study.Common.Database
{
    using System;
    using NHibernate;

    public class SessionProvider : ISessionProvider
    {
        private const string DEFAULT_SESSION_NAME = "__default_session__";

        private readonly ISessionFactory _sessionFactory;

        public SessionProvider(ISessionFactory sessionFactory) => _sessionFactory = sessionFactory;

        public void Open(Action<ISession> action) => Open(DEFAULT_SESSION_NAME, action);

        public void Open(string sessionName, Action<ISession> action) => OpenAndSelect(sessionName, session =>
        {
            action.Invoke(session);

            return 0;
        });

        public T OpenAndSelect<T>(Func<ISession, T> action) => OpenAndSelect(DEFAULT_SESSION_NAME, action);

        public T OpenAndSelect<T>(string sessionName, Func<ISession, T> action) => _sessionFactory.OpenSession().UsingAndSelect(session => action.Invoke(session));
    }
}
