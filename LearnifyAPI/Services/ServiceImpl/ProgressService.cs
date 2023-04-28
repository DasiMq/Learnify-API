using LearnifyAPI.Dtos;
using LearnifyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LearnifyAPI.Services.ServiceImpl
{
    public class ProgressService : IProgressService
    {
        private readonly LearnifyContext dbContext;
        public ProgressService(LearnifyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Progress>> getProgresses()
        {
            return await dbContext.Progresses.ToListAsync();
        }
        public async Task<Progress> getProgress(int progressId)
        {
            return await dbContext.Progresses.FindAsync(progressId);
        }

        public async Task<Progress> addProgress(AddProgress addProgress)
        {
            Guid guid = Guid.NewGuid();
            var progress = new Progress()
            {
                ProgressId = guid.GetHashCode(),
                CourseProgress = addProgress.CourseProgress,
                CompletionStatus = addProgress.CompletionStatus,
                Date = addProgress.Date,
                ProgressEnrollmentId = addProgress.ProgressEnrollmentId,
                ProgressCourseId = addProgress.ProgressCourseId,
            };

            await dbContext.Progresses.AddAsync(progress);
            await dbContext.SaveChangesAsync();

            return progress;
        }

        public async Task<Progress> updateProgress(int progressId, UpdateProgress updateProgress)
        {
            var progress = await dbContext.Progresses.FindAsync(progressId);

            if (progress == null)
            {
                return null;
            }

            progress.CompletionStatus = updateProgress.CompletionStatus;
            progress.Date = updateProgress.Date;

            await dbContext.SaveChangesAsync();

            return progress;
        }
    }
}
