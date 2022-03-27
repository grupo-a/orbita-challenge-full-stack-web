using Microsoft.AspNetCore.Mvc;
using System;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public string Create()
        {
            return "ok";
        }
    }
}
