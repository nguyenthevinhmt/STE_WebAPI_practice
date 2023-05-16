using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_test.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên sinh viên không được bỏ trống!")]
        [StringLength(100)]
        public string StudentName { get; set; }
        [StringLength(100)]
        public string StudentNumber { get; set; }
        public ICollection<Subject> Subjects { get; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; }
        public virtual LibraryCard LibraryCard { get; }
    }
}
