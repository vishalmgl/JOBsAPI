using System.Collections.Generic;

namespace SimpleJobAPI.DTOs
{
    public class JobDTO
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UserDTO> Users { get; set; }


    }
}
