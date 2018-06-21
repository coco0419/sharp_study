namespace Study.Common.Database.Repositories
{
    using NHibernate;
    using Study.Common.Database.Entities;
    using System;

    public class TokenRepository : AbstractRepository<Token>, ITokenRepository
    {
        public TokenRepository(ISession session) : base(session) { }

        public Token FindByValueAndUpdate(string value)
        {
            var token = Session.QueryOver<Token>().Where(x => x.Value == value).And(x => x.ExpiredAt >= DateTime.Now).SingleOrDefault();

            if (token != null)
            {
                token.ExpiredAt = DateTime.Now.AddMinutes(30);

                Session.Update(token);
            }

            return token;
        }
    }
}
