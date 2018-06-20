namespace Study.Common.Database
{
    using System.Collections.Generic;
    using NHibernate;

    public static class SessionManager
    {
        private static readonly IDictionary<string, ISessionProvider> _sessionProviders = new Dictionary<string, ISessionProvider>();

        public static void AddProvider<T>(ISessionFactory sessionFactory) => AddProvider(typeof(T).Name, sessionFactory);

        public static void AddProvider(string poolName, ISessionFactory sessionFactory) => _sessionProviders.Add(poolName, new SessionProvider(sessionFactory));

        public static ISessionProvider Provider<T>() => Provider(typeof(T).Name);

        public static ISessionProvider Provider(string poolName) => _sessionProviders.ContainsKey(poolName) ? _sessionProviders[poolName] : null;
    }
}
