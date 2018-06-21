namespace Study.Common.Database.Repositories
{
    using Study.Common.Database.Entities;

    public interface ITokenRepository : IRepository<Token>
    {
        Token FindByValueAndUpdate(string value);
    }
}
