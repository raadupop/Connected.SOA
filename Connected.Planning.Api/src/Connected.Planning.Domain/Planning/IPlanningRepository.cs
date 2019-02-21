using System.Collections.Generic;
using System.Threading.Tasks;
using Connected.Planning.Domain.Planning.Dto;

namespace Connected.Planning.Domain.Planning
{
    public interface IPlanningRepository 
    {
        Task<int> AddNewPlan(PersonalPlanDto personalPlan);

        List<PersonalPlanDto> GetAllPlans();

        PersonalPlanDto GetStrategicPlanBy(int id);

        void CreateScheduleTemplate(ScheduleTemplateDto scheduleTemplate);
    }
}
