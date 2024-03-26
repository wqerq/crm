using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Admin.Models
{
    public class Subject
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual IEnumerable<Lesson>? Lessons { get; set; }
    }
}
