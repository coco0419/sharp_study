namespace Study.Common.Database.Maps
{
    using FluentNHibernate.Mapping;
    using Study.Common.Database.Entities;

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");

            Id(x => x.Id).Column("id").GeneratedBy.Increment();
            Map(x => x.LoginId).Column("login_id");
            Map(x => x.Nickname).Column("nickname");
            Map(x => x.Password).Column("password");
        }
    }
}
