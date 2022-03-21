//using Back.Data;
//using Back.Data.Models.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HoneycombTT.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CourseController : ControllerBase
//    {
//        AppDbContext db;
//        public CourseController(AppDbContext context) => db = context;

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
//        {
//            return await db.Courses.ToListAsync();
//        }

//        [HttpGet("id")]
//        public async Task<ActionResult<Course>> GetCourseById(int id)
//        {
//            Course course = await db.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
//            if (course == null)
//            {
//                return NotFound();
//            }
//            return new ObjectResult(course);
//        }
//        [HttpPost]
//        public async Task<ActionResult<Course>> Post(Course course)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            db.Courses.Add(course);
//            await db.SaveChangesAsync();
//            return Ok(course);
//        }


//        [HttpPut]
//        public async Task<ActionResult<Course>> Put(int id)
//        {
//            if (!db.Courses.Any(x => x.CourseId == id))
//            {
//                return NotFound();
//            }
//            db.Update(id);
//            await db.SaveChangesAsync();
//            return Ok(id);
//        }
//    }
//}
