using Connected.Planning.Domain.Planning.Dto;

namespace Connected.Planning.Domain.Planning.GeneticAlgorithm
{
    public interface IOptimizationService
    {
        void OptimizeStrategicPlan(PersonalPlanDto personalPlan);
    }
}
