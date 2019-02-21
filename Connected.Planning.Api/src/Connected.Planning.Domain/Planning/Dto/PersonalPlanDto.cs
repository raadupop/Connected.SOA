using System;
using System.Collections.Generic;
using Connected.Planning.Domain.Abstract;

namespace Connected.Planning.Domain.Planning.Dto
{
    public class PersonalPlanDto : EntityBase
    { 
        public string Title { get; set; }

        public string MotivationStatement { get; set; } 

        public DateTime PlanStartsOn { get; set; }

        public DateTime PlanEndsOn { get; set; }

        public TimeSpan FreetimeStartsOn { get; set; }

        public TimeSpan FreeTimeEndsOn { get; set; }

        public int OwnerId { get; set; }

        public List<ActivityPlanEntryDto> Activities { get; set; }

        public List<ScheduleTemplateDto> ScheduleTemplate { get; set; }
    }
}
