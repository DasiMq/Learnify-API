using LearnifyAPI.Dtos;

namespace LearnifyAPI.Services
{
    public interface IProgressService
    {
        public Task<List<Progress>> getProgresses();
        public Task<Progress> getProgress(int courseId);
        public Task<Progress> addProgress(AddProgress addProgress);
        public Task<Progress> updateProgress(int progressId, UpdateProgress updateProgress);
    }
}
