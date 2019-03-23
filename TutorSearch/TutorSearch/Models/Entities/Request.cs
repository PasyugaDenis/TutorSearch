using System;

namespace TutorSearch.Models.Entities
{
    public class Request
    {
        public int Id { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsClosed { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public double? Rating { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }
}
