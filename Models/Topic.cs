using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DotNet_React_WebProject.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Number { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Filling { get; set; }
    }
}
