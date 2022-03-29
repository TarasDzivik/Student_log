using AutoMapper;
using AutoMapper.QueryableExtensions;
using Back.Data;
using Back.Data.DTOs;
using Back.Data.Models.Entities;
using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneycombTT.Controller
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public AppDbContext db;
        private readonly IMapper mapper;
        public CourseController(AppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses([FromQuery] PaginationParameters pagination)
        {
            return await db.Courses
                .ProjectTo<CourseDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<CourseDto>> GetCourseById(int id)
        {
            CourseDto course = await db.Courses
               .ProjectTo<CourseDto>(mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return new ObjectResult(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseCreateDto>> CreateCourse(CourseCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = mapper.Map<Course>(createDto);
            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return Ok(course);
        }

        [HttpPut]
        public async Task<ActionResult<Course>> CourseUpdate(int Id, [FromBody] Course course)
        {
            if (!db.Courses.Any(x => x.Id == course.Id))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                db.Courses.Update(course);
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError(nameof(CourseUpdate), "unable to update course");
                return StatusCode(500, ModelState);
            }
            return Ok(course); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Course>> Delete(int id)
        {
            Course course = db.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
            return Ok(course);
        }
    }
}
