using NHibernate;
using Study.Common.Database.Entities;

namespace Study.Common.Database.Repositories
{
    public class ChatRepository : AbstractRepository<Chat>, IChatRepository
    {
        public ChatRepository(ISession session) : base(session) { }
    }
}
