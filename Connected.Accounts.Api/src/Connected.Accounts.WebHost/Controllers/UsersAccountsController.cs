using System;
using System.Threading.Tasks;
using Connected.Accounts.Domain.Accounts;
using Connected.Accounts.Domain.Accounts.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Connected.Accounts.WebHost.Controllers
{
    [Route("api/accounts/[controller]")]
    public class UsersAccountsController : Controller
    {
        private readonly IMembershipService _membershipService;

        public UsersAccountsController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateNewUserAccount([FromBody] UserAccountRegistrationViewModel registerUserInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _membershipService.CreateNewUserAccount(registerUserInput);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetAll")]
        public IActionResult GetAllUsersAccounts()
        {
            var users = _membershipService.GetAllUsersAccounts();

            return Ok(users);
        }

        [HttpDelete]
        [Route("Delete/{userAccountId}")]
        public async Task<IActionResult> RemoveUserAccount(int userAccountId)
        {
            try
            {
                await _membershipService.DeleteUserAccount(userAccountId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateUserAccount([FromBody] UserAccountViewModel updatedUserAaAccountViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _membershipService.UpdateUserAccoutInformation(updatedUserAaAccountViewModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
