
using App.Webapi.Data;
using App.Webapi.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public AppDbContext Context { get; set; }
        public StudentsController(AppDbContext dbContext)
        {
            Context = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var students = Context.Students.ToList();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id) 
        { 
            var student = Context.Students.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Create([FromBody]StudentEntity student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            Context.Students.Add(student);
            Context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] StudentEntity newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = Context.Students.FirstOrDefault(X => X.Id == id);
            if (student == null) 
            {
                return NotFound();
            }
            student.UserName = newStudent.UserName;
            student.Name = newStudent.Name;
            student.Surname = newStudent.Surname;
            student.StudentNumber = newStudent.StudentNumber;
            student.Class = newStudent.Class;
            student.Password = newStudent.Password;
            Context.SaveChanges();
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) 
        { 
            var student = Context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            Context.Students.Remove(student);
            Context.SaveChanges();
            return Ok();
        }

    }
}
