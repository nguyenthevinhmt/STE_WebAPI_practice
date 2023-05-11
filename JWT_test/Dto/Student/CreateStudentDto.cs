using System.ComponentModel.DataAnnotations;

namespace JWT_test.Dto.Student
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "Tên sinh viên không được bỏ trống!")]
        [StringLength(100)]
        public string StudentName { get; set; }
        [StringLength(100)]
        public string StudentNumber { get; set; }
    }
}
