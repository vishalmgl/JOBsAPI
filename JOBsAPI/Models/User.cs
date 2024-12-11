using System.Collections.Generic;

namespace SimpleJobAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<JobAssignment> AssignedJobs { get; set; }
       
    }
}
