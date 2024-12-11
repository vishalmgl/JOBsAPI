using System.Collections.Generic;

namespace SimpleJobAPI.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        // Navigation Property
        public ICollection<JobAssignment> AssignedUsers { get; set; }

    }
}
