using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Connected.Planning.Domain.Planning.ViewModel
{
    public class PersonalPlanViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string MotivationStatement { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime PlanStartsOn { get; set; }

        [Required]
        public DateTime PlanEndsOn { get; set; }

        public int OwnerId { get; set; }

        [Required]
        public TimeSpan FreetimeStartsOn { get; set; }

        [Required]
        public TimeSpan FreeTimeEndsOn { get; set; }

        [Required]
        public List<ActivitySlotViewModel> Activities { get; set; }
    }
}
