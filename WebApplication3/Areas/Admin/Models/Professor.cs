using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Admin.Models
{
    public class Professor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        public virtual IEnumerable<Lesson>? Lessons { get; set; }
    }
}
