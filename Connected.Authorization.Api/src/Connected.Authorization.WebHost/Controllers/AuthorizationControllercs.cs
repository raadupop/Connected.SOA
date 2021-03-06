﻿using Connected.Authorization.Domain.Auth;
using Connected.Authorization.Domain.Auth.ViewModel;
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
        public IActionResult Authenticate([FromBody] AuthenticationInputViewModel authenticateInputViewModel)
        {
            if (ModelState.IsValid)
            {
                var authenticateResult = _authenticationService.GetAuthenticationResult(authenticateInputViewModel.Email, authenticateInputViewModel.Password);

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
