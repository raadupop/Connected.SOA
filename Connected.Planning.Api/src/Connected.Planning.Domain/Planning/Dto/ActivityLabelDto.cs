using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Connected.Planning.Domain.Planning.Dto
{
    public class ActivityLabelDto
    { 
        [Key]
        public string Name { get; set; }

        public List<ActivityPlanEntryDto> ActivityPlanEntries { get; set; }
    }
}
