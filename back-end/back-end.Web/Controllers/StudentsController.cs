using Microsoft.AspNetCore.Mvc;
using students_db.Models;
using students_db.Repository;

namespace back_end.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentsRepository _repository;
    public StudentsController(StudentsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var students = _repository.GetAll();
        return Ok(students);
    }

    [HttpGet("{id}", Name = "GetByPK")]
    public ActionResult GetByPK(int id)
    {
        var student = _repository.GetByPK(id);

        if (student == null) return NotFound("Student not found");

        return Ok(student);
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
        _repository.Create(student);

        return CreatedAtAction("GetById", new { student.RA }, student);
    }

    [HttpPut("{id}")]
    public ActionResult Update(Student student)
    {
        var validStudent = _repository.GetByPK(student.RA);

        if (validStudent == null) return NotFound("Student not found");

        _repository.Update(student);

        return Ok($"Student '{student.RA}' updated");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int ra)
    {
        var validStudent = _repository.GetByPK(ra);

        if (validStudent == null) return NotFound("Student not found");

        _repository.Delete(ra);

        return NoContent();
    }
}
