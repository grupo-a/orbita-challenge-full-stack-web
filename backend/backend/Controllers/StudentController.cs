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
        private static List<Student> students = new List<Student>();
        private static int id = 1;

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = id++;
            students.Add(student);
            return Ok(student);
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            Student student = students.FirstOrDefault(students => students.Id == id);
            return student != null ? Ok(student) : NotFound();
        }
    }
}
