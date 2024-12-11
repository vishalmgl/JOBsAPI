namespace SimpleJobAPI.Models
{
    public class JobAssignment
    {
        public int JobID { get; set; }
        public Job Job { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
