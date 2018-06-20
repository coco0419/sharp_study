namespace Study.Common.Database.Repositories
{
    using System;

    public interface IRepository<T> : IDisposable
    {
        object Create(T source);
    }
}
