using System.Threading.Tasks;
using AutoMapper;
using Connected.Planning.Domain.Planning;
using Connected.Planning.Domain.Planning.Dto;
using Connected.Planning.Domain.Planning.GeneticAlgorithm;
using Connected.Planning.Domain.Planning.ViewModel;

namespace Connected.Planning.Business.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly IPlanningRepository _planningRepository;
        private readonly IOptimizationService _optimizationService;
        private readonly IMapper _mapper;

        public PlanningService(IPlanningRepository planningRepository, IMapper mapper, IOptimizationService optimizationService)
        {
            _planningRepository = planningRepository;
            _mapper = mapper;
            _optimizationService = optimizationService;
        }

        public async Task AddNewPlan(PersonalPlanViewModel personalPlanViewModel)
        {
            var strategicPlanDto = _mapper.Map<PersonalPlanDto>(personalPlanViewModel);
            strategicPlanDto.Id = await _planningRepository.AddNewPlan(strategicPlanDto);

            _optimizationService.OptimizeStrategicPlan(strategicPlanDto);
        }

        public PersonalPlanViewModel GetStrategicPlanById(int id)
        {
            var strategicPlanDto = _planningRepository.GetStrategicPlanBy(id);

            return _mapper.Map<PersonalPlanViewModel>(strategicPlanDto);
        }
    }
}
