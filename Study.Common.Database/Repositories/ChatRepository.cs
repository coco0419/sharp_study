using NHibernate;
using Study.Common.Database.Entities;
using System.Collections.Generic;

namespace Study.Common.Database.Repositories
{
    public class ChatRepository : AbstractRepository<Chat>, IChatRepository
    {
        public ChatRepository(ISession session) : base(session) { }

        public IEnumerable<Chat> List()
        {
            Chat chatAlias = null;
            User userAlias = null;

            return Session.QueryOver(() => chatAlias).JoinAlias(() => chatAlias.User, () => userAlias).OrderBy(x => chatAlias.Id).Asc.List();
        }
    }
}
