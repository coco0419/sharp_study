namespace Study.Common.Database.Maps
{
    using FluentNHibernate.Mapping;
    using Study.Common.Database.Entities;

    public class ChatMap : ClassMap<Chat>
    {
        public ChatMap()
        {
            Table("chats");

            Id(x => x.Id).Column("id").GeneratedBy.Increment();
            Map(x => x.Message).Column("message");
            Map(x => x.UserId).Column("user_id");
            References(x => x.User).Column("user_id").ReadOnly();
        }
    }
}
