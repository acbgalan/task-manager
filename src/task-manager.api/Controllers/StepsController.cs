using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_manager.api.Responses.Step;
using task_manager.data;
using task_manager.data.Repositories.Interface;

namespace task_manager.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StepsController : ControllerBase
    {
        private readonly IStepRepository _stepRepository;
        private readonly IMapper _mapper;

        public StepsController(IStepRepository stepRepository, IMapper mapper)
        {
            _stepRepository = stepRepository;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "GetStep")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StepResponse>> GetStep(int id)
        {
            var step = await _stepRepository.GetAsync(id);

            if (step == null)
            {
                return NotFound("Step not found");
            }

            var stepResponse = _mapper.Map<StepResponse>(step);
            return Ok(stepResponse);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<StepResponse>>> GetAllSteps()
        {
            var steps = await _stepRepository.GetAllAsync();
            var stepsResponse = _mapper.Map<List<StepResponse>>(steps);

            return Ok(stepsResponse);
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<StepResponse>>> GetStepsByTaskId(string taskId)
        {
            Guid stepTaskId;

            if (!Guid.TryParse(taskId, out stepTaskId))
            {
                return BadRequest("The 'taskId' parameter is not valid. Make sure it is a valid Guid value.");
            }

            var steps = await _stepRepository.GetAllSteps(taskId);
            var stepsResponse = _mapper.Map<StepResponse>(steps);

            return Ok(stepsResponse);
        }

    }
}
