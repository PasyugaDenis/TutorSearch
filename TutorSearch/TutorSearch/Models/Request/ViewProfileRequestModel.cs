using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorSearch.Models.Request
{
    public class ViewProfileRequestModel
    {
        public int Id { get; set; }

        public bool IsTeacher { get; set; }
    }
}
