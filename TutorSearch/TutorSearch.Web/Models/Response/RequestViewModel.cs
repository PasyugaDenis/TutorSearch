using System;

namespace TutorSearch.Web.Models.Response
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public bool? IsConfirmed { get; set; }

        public bool IsClosed { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public double? Rating { get; set; }

        public string Comment { get; set; }

        public string StudentFullName { get; set; }
    }
}