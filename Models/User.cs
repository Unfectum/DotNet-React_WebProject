using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNet_React_WebProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required]
        public string Role { get; set; }
        public ICollection<Course> Courses { get; set; }
        public List<Request> Requests { get; set; }
    }
}
