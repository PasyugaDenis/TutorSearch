﻿using System;

namespace TutorSearch.Web.Models.Request
{
    public class UserRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool IsTeacher { get; set; }

        public string Password { get; set; }
    }
}