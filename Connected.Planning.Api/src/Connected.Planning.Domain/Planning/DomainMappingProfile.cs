using AutoMapper;
using Connected.Planning.Domain.Planning.Dto;
using Connected.Planning.Domain.Planning.ViewModel;

namespace Connected.Planning.Domain.Planning
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<ActivityPlanEntryDto, ActivityLabelViewModel>();
            CreateMap<ActivitySlotViewModel, ActivityPlanEntryDto>();

            CreateMap<PersonalPlanViewModel, PersonalPlanDto>();
            CreateMap<PersonalPlanDto, PersonalPlanViewModel>();

            CreateMap<ActivityLabelDto, ActivityLabelViewModel>();
            CreateMap<ActivityLabelViewModel, ActivityLabelDto>();
        }
    }
}
