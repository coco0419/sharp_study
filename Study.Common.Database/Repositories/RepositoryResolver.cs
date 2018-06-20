using System;
using System.Collections.Generic;
using NHibernate;

namespace Study.Common.Database.Repositories
{
    public static class RepositoryResolver
    {
        private static IDictionary<string, Type> _transients = new Dictionary<string, Type>();

        public static void AddTransient<TSource, TValue>() where TValue : TSource => _transients.Add(typeof(TSource).Name, typeof(TValue));

        public static T Resolve<T>(ISession session)
        {
            var name = typeof(T).Name;

            if (_transients.ContainsKey(name))
            {
                return (T)Activator.CreateInstance(_transients[name],new[] { session });
            }

            return default(T);
        }
    }
}
