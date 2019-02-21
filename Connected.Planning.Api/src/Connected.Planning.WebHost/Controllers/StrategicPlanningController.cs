using System;
using System.Threading.Tasks;
using Connected.Planning.Domain.Planning;
using Connected.Planning.Domain.Planning.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Connected.Planning.WebHost.Controllers
{
    [Route("api/planning/[controller]")]
    public class StrategicPlanningController : Controller
    {
        private readonly IPlanningService _planningService;

        public StrategicPlanningController(IPlanningService planningService)
        {
            _planningService = planningService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateNewStrategicPlan([FromBody] PersonalPlanViewModel personalPlanViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _planningService.AddNewPlan(personalPlanViewModel);

                return CreatedAtAction(nameof(GetStrategicPlanById), new { id = personalPlanViewModel.Id }, personalPlanViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPlanById/{planId}")]
        public IActionResult GetStrategicPlanById(int planId)
        {
            try
            {
                var plan = _planningService.GetStrategicPlanById(planId);
                if (plan == null)
                {
                    return NotFound();
                }

                return Ok(plan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
