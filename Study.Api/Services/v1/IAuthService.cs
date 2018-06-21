namespace Study.Api.Services.v1
{
    using Study.Api.Requests.v1;
    using Study.Api.Responses.v1;

    public interface IAuthService
    {
        AuthSignInResponse Authenticate(AuthSignInRequest request);
    }
}