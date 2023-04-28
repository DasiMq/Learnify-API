using LearnifyAPI.Dtos;
using LearnifyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnifyAPI.Services.ServiceImpl
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly LearnifyContext dbContext;
        public EnrollmentService(LearnifyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Enrollment>> getEnrollments()
        {
            return await dbContext.Enrollments.ToListAsync();
        }

        public async Task<Enrollment> getEnrollmentId(int enrollmentId)
        {
            return await dbContext.Enrollments.FindAsync(enrollmentId);
        }

        public async Task<Enrollment> addEnrollment(AddEnrollment addEnrollment)
        {
            Guid guid = Guid.NewGuid();
            var enrollment = new Enrollment()
            {
                EnrollmentId = guid.GetHashCode(),
                EnrollmentDate = addEnrollment.EnrollmentDate,
                PaymentStatus = addEnrollment.PaymentStatus,
                EnrollmentStudentId = addEnrollment.EnrollmentStudentId,
                EnrollmentCourseId = addEnrollment.EnrollmentCourseId,
            };
            enrollment.EnrollmentStudentId = 1;
            await dbContext.Enrollments.AddAsync(enrollment);
            await dbContext.SaveChangesAsync();

            return enrollment;
        }
    }
}
