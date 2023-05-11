using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_test.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên môn học không được bỏ trống!")]
        [StringLength(100)]
        public string SubjectName { get; set; }
        public ICollection<Student> Students { get; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; }

    }
}
