using JWT_test.Dto.Shared;
using JWT_test.Dto.Student;
using JWT_test.Models;

namespace JWT_test.Services.Interface
{
    public interface IStudents
    {
        List<ResponeStudentDto> GetAll();
        ResponeStudentDto GetById(int id);
        void CreateStudent(CreateStudentDto std);
        void UpdateStudent(ResponeStudentDto std);
        void DeleteStudent(int id);
        StudentSubject UpdatePoint(UpdatePointDto input);
        void AddSubjectForStudent(int subjectId, int studentId);
    }
}
