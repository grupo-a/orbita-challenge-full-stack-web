using App.School.Application.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.School.Api4.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery] StudentByIdQuery student)
        {
            var response = await _mediator.Send(student);
            return await Task.FromResult(Ok(response));
        }
    }
}