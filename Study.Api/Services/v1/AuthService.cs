namespace Study.Api.Services.v1
{
    using System;
    using Study.Api.Database;
    using Study.Api.Requests.v1;
    using Study.Common.Database;
    using Study.Common.Database.Entities;
    using Study.Common.Database.Repositories;
    using Study.Api.Form;
    using Study.Api.Responses.v1;

    public class AuthService : IAuthService
    {
        public AuthSignInResponse Authenticate(AuthSignInRequest request)
        {
            request.Valid();

            return SessionManager.Provider<Schema.Main>().OpenAndSelect(session =>
            {
                var user = RepositoryResolver.Resolve<IUserRepository>(session).UsingAndSelect(repository => repository.FindByLoginId(request.LoginId));

                if (user == null || !user.Verify(request.Password))
                {
                    throw new RequestInvalidException(new[] { new ValidationError(string.Empty, "error.invalidLoginIdOrPassword") });
                }

                return RepositoryResolver.Resolve<ITokenRepository>(session).UsingAndSelect(repository =>
                {
                    var token = Token.Build(user);
                    token.Id = repository.Create(token) as long?;

                    return new AuthSignInResponse()
                    {
                        Token = token,
                        User = user
                    };
                });
            });
        }
    }
}