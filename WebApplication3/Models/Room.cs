using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Number { get; set; }

        public virtual IEnumerable<Lesson>? Lessons { get; set; }

    }
}
