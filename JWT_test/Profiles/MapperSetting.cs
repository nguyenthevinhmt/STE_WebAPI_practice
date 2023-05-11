
using AutoMapper;
using JWT_test.Dto.Student;
using JWT_test.Dto.Subject;
using JWT_test.Models;

namespace JWT_test.Profiles
{
    public class MapperSetting : Profile
    {
        public MapperSetting()
        {
            // For Student
            CreateMap<Student, ResponeStudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdatePointDto>().ReverseMap();
            //For Subject
            CreateMap<Subject, ResponeSubjectDto>().ReverseMap();
            CreateMap<Subject, CreateSubjectDto>().ReverseMap();
        }
    }
}
