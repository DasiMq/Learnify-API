using LearnifyAPI.Dtos;
using LearnifyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnifyAPI.Services.ServiceImpl
{

    public class CourseService : ICourseService
    {
        private readonly LearnifyContext dbContext;
        public CourseService(LearnifyContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Course>> getCourses()
        {
            return await dbContext.Courses.ToListAsync();
        }

        public async Task<Course> getCourseId(int courseId)
        {
            return await dbContext.Courses.FindAsync(courseId);
        }

        public async Task<Course> addCourse(AddCourse addCourse)
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
            
            return course;
        }

        public async Task<Course> updateCourse(int courseId, UpdateCourse updateCourse)
        {
            var course = await dbContext.Courses.FindAsync(courseId);

            if (course == null)
            {
                return null;
            }

            course.CourseName = updateCourse.CourseName;
            course.CourseDescription = updateCourse.CourseDescription;
            course.CourseDuration = updateCourse.CourseDuration;
            course.CoursePrice = updateCourse.CoursePrice;

            await dbContext.SaveChangesAsync();

            return course;
          
        }

        public async Task<Course> deleteCourse(int courseId)
        {
            var course = await dbContext.Courses.FindAsync(courseId);

            if (course == null )
            {
                return null;
            }

            dbContext.Remove(course);
            await dbContext.SaveChangesAsync();

            return course;
        }
    }

}
