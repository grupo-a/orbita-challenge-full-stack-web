using backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
    }
}
