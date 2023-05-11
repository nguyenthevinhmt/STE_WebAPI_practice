using JWT_test.Dto.Subject;
using JWT_test.Models;

namespace JWT_test.Services.Interface
{
    public interface ISubject
    {
        List<ResponeSubjectDto> GetAll();
        ResponeSubjectDto GetById(int id);
        void CreateSubject(CreateSubjectDto subjects);
        void UpdateSubjects(ResponeSubjectDto subjects);
        void DeleteSubjects(int id);
    }
}
