using AutoMapper;
using backend.Data;
using backend.Data.Dtos;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentContext _context;
        private IMapper _mapper;

        public StudentController(StudentContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateStudentDTO studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);
            if(
                _context.Students.FirstOrDefault(students => students.Ra == studentDto.Ra) == null &&
                _context.Students.FirstOrDefault(students => students.Cpf == studentDto.Cpf) == null
             )
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return CreatedAtAction(nameof(FindById), new { Id = student.Id }, student);
            }
            return BadRequest("Error, student with RA or CPF already registered");
        }

        [HttpGet]
        public IEnumerable<Student> FindAll()
        {
            return _context.Students;
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            Student student = _context.Students.FirstOrDefault(students => students.Id == id);
            return student != null ? Ok(student) : NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateStudentDTO studentDTO)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _mapper.Map(studentDTO, student);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Student student = _context.Students.FirstOrDefault(student => student.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
