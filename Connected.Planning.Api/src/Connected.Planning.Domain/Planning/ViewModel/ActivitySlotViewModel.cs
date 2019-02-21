using System;
using System.ComponentModel.DataAnnotations;

namespace Connected.Planning.Domain.Planning.ViewModel
{
    public class ActivitySlotViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime ActivityDeadline { get; set; }

        [Required]
        public TimeSpan TimeAllocation { get; set; }

        [Required]
        public int Priority { get; set; }

        public ActivityLabelViewModel ActivityLabel { get; set; }
    }
}
