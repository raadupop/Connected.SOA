using Connected.Planning.Domain.Abstract;

namespace Connected.Planning.Domain.Planning.Dto
{
    public class ScheduleOptimizationType : NamedEntity
    {
        public OptimizationModel Classification { get; set; }
    }
}
