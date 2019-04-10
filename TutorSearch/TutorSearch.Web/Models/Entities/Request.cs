using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorSearch.Web.Models.Entities
{
    public class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsClosed { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public double? Rating { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }
}
