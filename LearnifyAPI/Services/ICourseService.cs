using LearnifyAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LearnifyAPI.Services
{
    public interface ICourseService
    {
        public Task<List<Course>> getCourses();
        public Task<Course> getCourseId(int courseId);
        public Task<Course> addCourse(AddCourse addCourse);
        public Task<Course> updateCourse(int courseId, UpdateCourse updateCourse);
        public Task<Course> deleteCourse(int courseId);
    }
}
