using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Connected.Accounts.Domain.Accounts;
using Connected.Accounts.Domain.Accounts.Dto;
using Connected.Accounts.Domain.Accounts.ViewModel;

namespace Connected.Accounts.Business.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;
        private readonly IMapper _mapper;

        public MembershipService(IMembershipRepository membershipRepository, IMapper mapper)
        {
            _membershipRepository = membershipRepository;
            _mapper = mapper;
        }

        public async Task CreateNewUserAccount(UserAccountRegistrationViewModel registerUser)
        {
            if (_membershipRepository.IsUserAlreadyRegistered(registerUser.Email))
            {
                throw new InvalidOperationException("User already exists.");
            }

            var newUserDto = _mapper.Map<UserAccountDto>(registerUser);
            newUserDto.IsActive = true;
            newUserDto.DateCreated = DateTime.Now;
            await _membershipRepository.CreateNewUserAccount(newUserDto);
        }

        public UserAccountGridViewModel GetAllUsersAccounts()
        {
            var users = _membershipRepository.GetAllUsers();

            // ToDo: Implement pagination
            return new UserAccountGridViewModel()
            {
                UserAccounts = _mapper.Map<List<UserAccountViewModel>>(users),
                PageNumber = 1
            };
        }

        public async Task DeleteUserAccount(int userAccountId)
        {
            var userToBeDeleted = _membershipRepository.FindUserById(userAccountId);

            if (userToBeDeleted != null)
            {
                await _membershipRepository.DeleteUser(userToBeDeleted);

                return;
            }

            throw new KeyNotFoundException("Item not found");
        }

        public async Task UpdateUserAccoutInformation(UserAccountViewModel updatedUserAccount)
        {
            var targetedUserAccount = _membershipRepository.FindUserById(updatedUserAccount.Id);

            if (targetedUserAccount == null)
            {
                throw new KeyNotFoundException("Users was not found.");
            }

            targetedUserAccount.Email = updatedUserAccount.Email;
            targetedUserAccount.FirstName = updatedUserAccount.FirstName;
            targetedUserAccount.LastName = updatedUserAccount.LastName;
            targetedUserAccount.Username = updatedUserAccount.Username ?? targetedUserAccount.Username;

            await _membershipRepository.UpdateUserAccoutInformation(_mapper.Map<UserAccountDto>(targetedUserAccount));
        }
    }
}
