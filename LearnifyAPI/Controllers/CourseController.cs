using LearnifyAPI.Dtos;
using LearnifyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

namespace LearnifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly LearnifyContext dbContext;

        public CourseController(LearnifyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(await dbContext.Courses.ToListAsync());
        }

        [HttpGet]
        [Route("{CourseId:int}")]
        public async Task<IActionResult> GetCourse([FromRoute] int CourseId)
        {
            var course = await dbContext.Courses.FindAsync(CourseId);

            if(course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourse addCourse)
        {
            
            Guid guid = Guid.NewGuid();
            var course = new Course()
            {
                CourseId = guid.GetHashCode(),
                CourseName = addCourse.CourseName,
                CourseDescription = addCourse.CourseDescription,
                CourseDuration = addCourse.CourseDuration,
                CoursePrice = addCourse.CoursePrice,

        };
            course.CourseUserId = 2;
            await dbContext.Courses.AddAsync(course);
            await dbContext.SaveChangesAsync();

            return Ok(course);
        }

        [HttpPut]
        [Route("{CourseId:int}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] int CourseId, UpdateCourse updateCourse)
        {
            var course = await dbContext.Courses.FindAsync(CourseId);
            
            if (course != null)
            {
                course.CourseName = updateCourse.CourseName;
                course.CourseDescription = updateCourse.CourseDescription;  
                course.CourseDuration = updateCourse.CourseDuration;
                course.CoursePrice = updateCourse.CoursePrice;

                await dbContext.SaveChangesAsync();

                return Ok(course);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{CourseId:int}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int CourseId)
        {
            var course = await dbContext.Courses.FindAsync(CourseId);

            if (course != null)
            {
                dbContext.Remove(course);
                await dbContext.SaveChangesAsync();
                return Ok(course);
            }

            return NotFound();
        }
    } 
}
