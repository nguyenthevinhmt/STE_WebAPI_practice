using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_test.Models
{
    [Table("StudentSubject")]
    public class StudentSubject
    {
        [Key]
        public int Id { get; set; }
        [Range(0, 10)]
        public double Point{ get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

    }
}
