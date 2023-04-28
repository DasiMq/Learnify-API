using LearnifyAPI.Dtos;
using LearnifyAPI.Models;
using LearnifyAPI.Services;
using LearnifyAPI.Services.ServiceImpl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

namespace LearnifyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : Controller
    {
        private readonly IProgressService _progressService;

        public ProgressController(IProgressService progressService)
        {
            this._progressService = progressService;
        }

        [HttpGet]
        public async Task<IActionResult> getProgresses()
        {
            return Ok(await _progressService.getProgresses());
        }

        [HttpGet]
        [Route("{progressId:int}")]
        public async Task<IActionResult> getProgress([FromRoute] int progressId)
        {
            var progress = await _progressService.getProgress(progressId);

            if (progress == null)
            {
                return NotFound();
            }

            return Ok(progress);
        }

        [HttpPost]
        public async Task<IActionResult> addProgress(AddProgress addProgress)
        {
            return Ok(await _progressService.addProgress(addProgress));
        }

        [HttpPut("{progressId:int}")]
        public async Task<IActionResult> updateProgress([FromRoute] int progressId, UpdateProgress updateProgress)
        {
            var progress = await _progressService.updateProgress(progressId, updateProgress);

            if (progress == null)
            {
                return NotFound();
            }

            return Ok(progress);
        }
    }
}
