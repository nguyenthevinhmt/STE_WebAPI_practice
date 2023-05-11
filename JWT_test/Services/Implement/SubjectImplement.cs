using AutoMapper;
using JWT_test.Context;
using JWT_test.Dto.Student;
using JWT_test.Dto.Subject;
using JWT_test.Exceptions;
using JWT_test.Models;
using JWT_test.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JWT_test.Services.Implement
{
    public class SubjectImplement : ISubject
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SubjectImplement(AppDbContext context, IMapper mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        public void CreateSubject(CreateSubjectDto subjects)
        {
            var result = _mapper.Map<Models.Subject>(subjects);
            _context.Subjects.Add(result);
            _context.SaveChanges();
        }

        public void DeleteSubjects(int id)
        {
            var result = _context.Subjects.FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                throw new UserFriendlyException($"Môn học có {id} không tồn tại");
            }
            _context.Remove(result);
            _context.SaveChanges();
        }

        public List<ResponeSubjectDto> GetAll()
        {
            var a = _context.Subjects.ToList();
            var result = _mapper.Map<List<ResponeSubjectDto>>(a);
            return result;
        }

        public ResponeSubjectDto GetById(int id)
        {
            var check = _context.Subjects.FirstOrDefault(c => c.Id == id);
            if (check == null)
            {
                throw new UserFriendlyException($"Không tìm thấy môn học có ID là {id}");
            }
            else
            {
                var result = _mapper.Map<ResponeSubjectDto>(check);
                return result;
            }
        }

        public void UpdateSubjects(ResponeSubjectDto subjects)
        {
            var result = _context.Subjects.FirstOrDefault(c => c.Id == subjects.Id);
            if (result == null)
            {
                throw new UserFriendlyException($"Môn học có ID {subjects.Id} không tồn tại");
            }
            result.Id = subjects.Id;
            result.SubjectName = subjects.SubjectName;
            _context.SaveChanges();
        }
    }
}
