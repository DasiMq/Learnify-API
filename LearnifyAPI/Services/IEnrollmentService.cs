using LearnifyAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LearnifyAPI.Services
{
    public interface IEnrollmentService
    {
        public Task<List<Enrollment>> getEnrollments();
        public Task<Enrollment> getEnrollmentId(int enrollmentId);
        public Task<Enrollment> addEnrollment(AddEnrollment addEnrollment);
    }
}
