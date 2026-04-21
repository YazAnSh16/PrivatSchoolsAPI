using CQRS_LB.CQRS.Commands;
using CQRS_LB.CQRS.DTOs;
using CQRS_LB.CQRS.Queries;
using CQRS_LB.Data.Models;
using CQRS_LB.Repos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PrivatSchoolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public StudentController(IRepo<Student> repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;

        }
        private readonly IRepo<Student> _repo;
        private readonly IMediator _mediator;


        /// <summary>
        /// Get all students from the system
        /// </summary>
        /// <returns>A list of all students</returns>

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            //var students = await _repo.GetAll().ToListAsync();
            //return Ok(students);
            var result = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(DtoNewStudent student)
        {
            //await _repo.Add(student);
            //return Ok(student);

            var results = await _mediator.Send(new AddNewStudentCommand(student));
            return Ok(results);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            var result = await _mediator.Send(new DeleteStudentCommand(id));
            if (!result)
                return NotFound();
            return Ok("removed"); // 200
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, DtoUpdateStudent student)
        {
            var result = await _mediator.Send(new UpdateStudentCommand(id, student));
            if (!result)
                return NotFound();
            return Ok("updated");
        }
    }
}
