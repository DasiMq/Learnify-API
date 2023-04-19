using LearnifyAPI.Dtos;
using LearnifyAPI.Models;
using LearnifyAPI.Services;
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

        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> getCourses()
        {
            return Ok(await courseService.getCourses());
        }


        [HttpGet]
        [Route("{courseId:int}")]
        public async Task<IActionResult> GetCourse([FromRoute] int courseId)
        {
            var course = await courseService.getCourseId(courseId);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> addCourse(AddCourse addCourse)
        {
            return Ok(await courseService.addCourse(addCourse));
        }

        [HttpPut("{courseId:int}")]
        public async Task<IActionResult> updateCourse([FromRoute] int courseId, UpdateCourse updateCourse)
        {
            var course = await courseService.updateCourse(courseId,updateCourse);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpDelete]
        [Route("{courseId:int}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int courseId)
        {
            var course = await courseService.deleteCourse(courseId);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
    }
}
