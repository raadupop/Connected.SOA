using System;
using System.ComponentModel.DataAnnotations;
using Connected.Planning.Domain.Abstract;

namespace Connected.Planning.Domain.Planning.Dto
{
    [Serializable]
    public class ActivityPlanEntryDto : EntityBase
    { 
        [Required]
        public string Name { get; set; }
    
        public string Description { get; set; }

        [Required]
        public DateTime ActivityDeadline { get; set; }

        [Required]
        public TimeSpan TimeAllocation { get; set; }
                        
        [Required]
        public int Priority { get; set; }


        public string ActivityLabelName { get; set; }

        public ActivityLabelDto ActivityLabel { get; set; }

        public int PersonalPlanId { get; set; }

        public PersonalPlanDto PersonalPlan { get; set; }
    }
}
