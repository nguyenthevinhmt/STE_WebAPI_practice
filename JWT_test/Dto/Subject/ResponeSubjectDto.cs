using System.ComponentModel.DataAnnotations;

namespace JWT_test.Dto.Subject
{
    public class ResponeSubjectDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên môn học không được bỏ trống!")]
        [StringLength(100)]
        public string SubjectName { get; set; }
       
    }
}
