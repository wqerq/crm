using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Group
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Number { get; set; }
        public virtual IEnumerable<Lesson>? Lessons { get; set; }
        public virtual IEnumerable<Student>? Students { get; set; }

    }
}
