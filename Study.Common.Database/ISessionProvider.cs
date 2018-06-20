namespace Study.Common.Database
{
    using System;
    using NHibernate;

    public interface ISessionProvider
    {
        void Open(Action<ISession> action);
        void Open(string sessionName, Action<ISession> action);
        T OpenAndSelect<T>(Func<ISession, T> action);
        T OpenAndSelect<T>(string sessionName, Func<ISession, T> action);
    }
}
