﻿using System.Threading.Tasks;
using TutorSearch.Web.Models.Entities;
using TutorSearch.Web.Repositories.RequestRepository;

namespace TutorSearch.Web.Services.RequestService
{
    public class RequestReadService : IRequestReadService
    {
        private IRequestReadRepository requestReadRepository;

        public RequestReadService(IRequestReadRepository requestReadRepository)
        {
            this.requestReadRepository = requestReadRepository;
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            var course = await requestReadRepository.GetAsync(id);

            return course;
        }
    }
}
