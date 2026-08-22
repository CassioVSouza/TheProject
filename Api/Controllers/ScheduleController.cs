using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using The_Project.Application.Features.Schedule.Commands.CreateSchedule;
using The_Project.Application.Features.Schedule.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace The_Project.Api.Controllers
{
    [ApiController]
    [Route("/v1")]
    public class ScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(IMediator mediator, ILogger<ScheduleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("/CreateSchedule")]
        public async Task<IActionResult> CreateSchedule([FromBody]CreateScheduleCommand command, CancellationToken cancellation)
        {
            try
            {
                _logger.LogInformation($"{DateTime.UtcNow} | {command} Reaches /CreateSchedule endpoint");

                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex) {
                _logger.LogError($"{DateTime.UtcNow} | Error in endpoint /CreateSchedule :{ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/GetSchedules")]
        public async Task<IActionResult> GetSchedules([FromQuery]GetScheduleQuery request, CancellationToken cancellation)
        {
            try
            {
                _logger.LogInformation($"{DateTime.UtcNow} | {request} Reaches /GetSchedules endpoint");

                var result = await _mediator.Send(request);

                if (result.Count == 0)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex) {
                _logger.LogError($"{DateTime.UtcNow} | Error in endpoint /GetSchedules :{ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
