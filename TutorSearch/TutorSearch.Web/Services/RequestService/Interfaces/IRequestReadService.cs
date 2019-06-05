﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;

namespace TutorSearch.Web.Services.RequestService
{
    public interface IRequestReadService
    {
        Task<Request> GetByIdAsync(int id);
        Task<List<Request>> GetByCourseIdAsync(int courseId);
    }
}
