namespace Study.Common.Database.Repositories
{
    using Study.Common.Database.Entities;
    using System.Collections.Generic;

    public interface IChatRepository : IRepository<Chat>
    {
        IEnumerable<Chat> List();
    }
}
