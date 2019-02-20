using Connected.Auth.Domain.Auth.ViewModel;
using Connected.Authorization.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connected.Authorization.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthorizationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationViewModel authenticateViewModel)
        {
            if (ModelState.IsValid)
            {
                var authenticateResult = _authenticationService.GetAuthenticationResult(authenticateViewModel.Email, authenticateViewModel.Password);

                if (authenticateResult == null)
                {
                    return BadRequest();
                }

                return Ok(authenticateResult);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        [Route("Authorize")]
        public IActionResult Authorize()
        {
            return Ok();
        }
    }
}
