using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Connected.Planning.Domain.Abstract;

namespace Connected.Planning.Domain.Planning.Dto
{
    public class ScheduleTemplateDto : EntityBase
    {
        public string Name { get; set; }

        public ScheduleOptimizationType OptimizationModel { get; set; }


        [Required]
        public int PersonalPlanId { get; set; }

        public PersonalPlanDto PersonalPlan { get; set; }

        public List<ScheduleEventDto> ScheduleActivities { get; set; }
    }
}
