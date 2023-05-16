using JWT_test.Dto.Shared;
using JWT_test.Dto.Student;
using JWT_test.Models;
using System.Collections;

namespace JWT_test.Services.Interface
{
    public interface IStudents
    {
        List<ResponeStudentDto> GetAll();
        ResponeStudentDto GetById(int id);
        void CreateStudent(CreateStudentDto std);
        void UpdateStudent(ResponeStudentDto std);
        void DeleteStudent(int id);
        void UpdatePoint(UpdatePointDto input);
        void AddSubjectForStudent(int subjectId, int studentId);
        List<StudentSubjectDto> GetListPointOfStudent(int studentId);
        //IEnumerable ListStudentInSubjectClass(int id);
        string CreateCard(CardDto card);
        IQueryable CardInfo(int id);
    }
}
