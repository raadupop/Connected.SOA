using System.Threading.Tasks;
using Connected.Planning.Domain.Planning.ViewModel;

namespace Connected.Planning.Domain.Planning
{
    public interface IPlanningService
    {
        Task AddNewPlan(PersonalPlanViewModel planViewModel);

        PersonalPlanViewModel GetStrategicPlanById(int id);
    }
}
