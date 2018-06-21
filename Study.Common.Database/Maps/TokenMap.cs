namespace Study.Common.Database.Maps
{
    using FluentNHibernate.Mapping;
    using Study.Common.Database.Entities;

    public class TokenMap : ClassMap<Token>
    {
        public TokenMap()
        {
            Table("tokens");

            Id(x => x.Id).Column("id").GeneratedBy.Increment();
            Map(x => x.Value).Column("value");
            Map(x => x.Secret).Column("secret");
            Map(x => x.ExpiredAt).Column("expired_at");
        }
    }
}
