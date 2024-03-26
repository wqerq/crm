using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Admin.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Student_GroupId { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MidName { get; set; }
        public virtual Group? Student_Group { get; set; }

    }
}
