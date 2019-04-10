﻿using System.Threading.Tasks;
using TutorSearch.Web.Models.Response;

namespace TutorSearch.Web.Services.StudentService
{
    public interface IStudentReadService
    {
        Task<StudentViewModel> ViewStudentByIdAsync(int id);
    }
}