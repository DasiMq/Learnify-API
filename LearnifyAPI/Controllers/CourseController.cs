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

        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> getCourses()
        {
            return Ok(await _courseService.getCourses());
        }


        [HttpGet]
        [Route("{courseId:int}")]
        public async Task<IActionResult> GetCourse([FromRoute] int courseId)
        {
            var course = await _courseService.getCourseId(courseId);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> addCourse(AddCourse addCourse)
        {
            return Ok(await _courseService.addCourse(addCourse));
        }

        [HttpPut("{courseId:int}")]
        public async Task<IActionResult> updateCourse([FromRoute] int courseId, UpdateCourse updateCourse)
        {
            var course = await _courseService.updateCourse(courseId,updateCourse);

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
            var course = await _courseService.deleteCourse(courseId);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
    }
}
