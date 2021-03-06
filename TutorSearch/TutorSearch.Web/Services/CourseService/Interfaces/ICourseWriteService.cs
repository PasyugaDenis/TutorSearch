﻿using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.CourseService
{
    public interface ICourseWriteService
    {
        Task<Course> AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task RemoveCourseAsync(Course course);
    }
}
