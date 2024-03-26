using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Lesson
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Lesson_GroupId { get; set; }
        [Required]
        public int Lesson_ProfessorId { get; set; }
        [Required]
        public int Lesson_SubjectId { get; set; }
        [Required]
        public int Lesson_RoomId { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        public virtual Group? Lesson_Group { get; set; }
        public virtual Professor? Lesson_Professor { get; set; }
        public virtual Subject? Lesson_Subject { get; set; }
        public virtual Room? Lesson_Room { get; set; }

        public override string ToString()
        {
            return string.Format("Предмет: {0}\nПреподаватель: {1} {2} {3}\nАудитория: {4}\nГруппа: {5}", Lesson_Subject.Name, Lesson_Professor.SurName, Lesson_Professor.FirstName, Lesson_Professor.MidName, Lesson_Room.Number, Lesson_Group.Number);
        }

    }
}
