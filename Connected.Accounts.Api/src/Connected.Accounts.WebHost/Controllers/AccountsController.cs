using System;
using System.Threading.Tasks;
using Connected.Accounts.Domain.Accounts;
using Connected.Accounts.Domain.Accounts.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Connected.Accounts.WebHost.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IMembershipService _membershipService;

        public AccountsController(IMembershipService membershipService)
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
        public IActionResult GetAllUsers()
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
        public async Task<IActionResult> UpdateUser([FromBody] UserAccountViewModel updatedUserAaAccountViewModel)
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
