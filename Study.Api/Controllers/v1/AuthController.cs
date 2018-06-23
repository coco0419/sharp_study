namespace Study.Api.Controllers.v1
{
    using Study.Api.Requests.v1;
    using Study.Api.Services.v1;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/v1/auth")]
    public class AuthController : AbstractController
    {
        private readonly IAuthService _authService;

        public AuthController() : this(new AuthService()) { }

        public AuthController(IAuthService authService) => _authService = authService;

        [Route]
        [HttpPost]
        public IHttpActionResult SignIn([FromBody] AuthSignInRequest source) => Try(() => _authService.Authenticate(source), Json, Error);
    }
}