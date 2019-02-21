using AutoMapper;
using Connected.Accounts.Domain.Accounts.Dto;
using Connected.Accounts.Domain.Accounts.ViewModel;

namespace Connected.Accounts.Domain
{
    public sealed class DomainMappingsProfile : Profile
    {
        public DomainMappingsProfile()
        {
            CreateMap<UserAccountRegistrationViewModel, UserAccountDto>();
            CreateMap<UserAccountDto, UserAccountViewModel>().ReverseMap();
        }
    }
}
