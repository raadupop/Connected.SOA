using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connected.Planning.Domain.Planning;
using Connected.Planning.Domain.Planning.Dto;
using Microsoft.EntityFrameworkCore;

namespace Connected.Planning.Data.Repository
{
    public class PlanningRepository : IPlanningRepository
    {
        private readonly PlanningDbContext _dbContext;

        public PlanningRepository(PlanningDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddNewPlan(PersonalPlanDto personalPlan)
        {
            _dbContext.PersonalPlans.Add(personalPlan);
            await _dbContext.SaveChangesAsync();

            return personalPlan.Id;
        }

        public List<PersonalPlanDto> GetAllPlans()
        {
            return _dbContext.PersonalPlans.Include(plansWith => plansWith.Activities).ToList();
        }

        public PersonalPlanDto GetStrategicPlanBy(int id)
        {
            return _dbContext.PersonalPlans.Include(planWith => planWith.Activities)
                .FirstOrDefault(p => p.Id == id);
        }

        public void CreateScheduleTemplate(ScheduleTemplateDto scheduleTemplate)
        {
            _dbContext.ScheduleTemplates.Add(scheduleTemplate);
            _dbContext.SaveChanges();
        }
    }
}
