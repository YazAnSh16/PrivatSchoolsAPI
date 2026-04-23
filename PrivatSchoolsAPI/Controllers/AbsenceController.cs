using Application.Features.Absence.Command.AddAbsence;
using Application.Features.Absence.Command.UpdateAbsence;
using Application.Features.Absence.Query.GetAbsenceByStudentId;
using CQRS_LB.CQRS.Commands;
using CQRS_LB.CQRS.DTOs;
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


        /// <summary>
        /// Add a new absence record for a student
        /// </summary>
        /// <param name="absence">Absence details including student id, result, and date</param>
        /// <returns>Created absence record</returns>
        /// <response code="200">Absence created successfully</response>
        /// <response code="400">Invalid request data</response>
        [HttpPost]
        public async Task<IActionResult> AddAbsence([FromBody] AddAbsenceRequest absence)
        {
            var command = new AddAbsenceCommand(absence.Result, absence.StudentId, absence.AbsenceDate);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get all absence records for a specific student
        /// </summary>
        /// <param name="id">Student unique identifier</param>
        /// <returns>List of absence records</returns>
        /// <response code="200">Returns absence records</response>
        /// <response code="404">No records found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbsenceByStudentId(int id)
        {
            var result = await _mediator.Send(new GetAbsenceByStudentIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        /// <summary>
        /// Delete an absence record
        /// </summary>
        /// <param name="id">Absence record id</param>
        /// <returns>No content if deleted</returns>
        /// <response code="204">Deleted successfully</response>
        /// <response code="404">Record not found</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsence(int id)
        {
            var result = await _mediator.Send(new DeleteAbsenceCommand(id));
            if (!result)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Update an existing absence record
        /// </summary>
        /// <param name="id">Absence record id</param>
        /// <param name="absence">Updated absence data</param>
        /// <returns>Updated absence record</returns>
        /// <response code="200">Updated successfully</response>
        /// <response code="404">Record not found</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAbsence(int id, UpdateAbsenceRequest absence)
        {

            var command = new UpdateAbsenceCommand(id, absence.Result, absence.AbsenceDate);

            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
