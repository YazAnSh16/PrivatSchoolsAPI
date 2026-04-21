using CQRS_LB.CQRS.Commands;
using CQRS_LB.CQRS.DTOs;
using CQRS_LB.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PrivatSchoolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        public AbsenceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        [HttpPost]
        public async Task<IActionResult> AddAbsence([FromBody] DtoNewAbsence absence)
        {
            var result = await _mediator.Send(new AddNewAbsenceCommand(absence));
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbsenceByStudentId(int id)
        {
            var result = await _mediator.Send(new GetAbsenceByStudentIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            var result = await _mediator.Send(new DeleteAbsenceCommand(id));
            if (!result)
                return NotFound();
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbsence([FromBody] DtoUpdateAbsence absence)
        {
            var result = await _mediator.Send(new UpdateAbsenceCommand(absence));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
