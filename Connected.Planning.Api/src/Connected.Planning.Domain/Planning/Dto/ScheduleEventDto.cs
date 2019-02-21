using System;
using System.ComponentModel.DataAnnotations;
using Connected.Planning.Domain.Abstract;

namespace Connected.Planning.Domain.Planning.Dto
{
    public class ScheduleEventDto : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartsOn { get; set; }

        public DateTime EndsOn { get; set; }


        public int ScheduleTemplateId { get; set; }

        public ScheduleTemplateDto ScheduleTemplate { get; set; }
    }
}
