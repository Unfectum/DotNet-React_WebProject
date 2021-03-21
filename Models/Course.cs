using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNet_React_WebProject.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public List<Request> Requests { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
