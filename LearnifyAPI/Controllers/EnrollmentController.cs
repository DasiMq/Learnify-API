using LearnifyAPI.Dtos;
using LearnifyAPI.Services;
using LearnifyAPI.Services.ServiceImpl;
using Microsoft.AspNetCore.Mvc;

namespace LearnifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {

        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            this._enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult> getEnrollments()
        {
            return Ok(await _enrollmentService.getEnrollments());
        }

        [HttpGet]
        [Route("{enrollmentId:int}")]
        public async Task<IActionResult> getEnrollmentId([FromRoute] int enrollmentId)
        {
            var enrollment = await _enrollmentService.getEnrollmentId(enrollmentId);

            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> addEnrollment(AddEnrollment addEnrollment)
        {
            return Ok(await _enrollmentService.addEnrollment(addEnrollment));
        }
    }
}
