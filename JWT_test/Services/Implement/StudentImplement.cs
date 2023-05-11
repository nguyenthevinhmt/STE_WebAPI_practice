﻿using AutoMapper;
using JWT_test.Context;
using JWT_test.Dto.Shared;
using JWT_test.Dto.Student;
using JWT_test.Exceptions;
using JWT_test.Models;
using JWT_test.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace JWT_test.Services.Implement
{
    public class StudentImplement : IStudents
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
       

        public StudentImplement(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        public List<Dto.Student.ResponeStudentDto> GetAll()
        {
            var a = _context.Students.ToList();
            var result = _mapper.Map<List<ResponeStudentDto>>(a);
            return result;
        }

        public ResponeStudentDto GetById(int id)
        {
            var check = _context.Students.FirstOrDefault(c => c.Id == id);
            if(check == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có ID là {id}");
            }
            else
            {
                var result = _mapper.Map<ResponeStudentDto>(check);
                return result;
            }
            
        }
        public void CreateStudent(CreateStudentDto std)
        {
            var student = _mapper.Map<Models.Student>(std);
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(ResponeStudentDto std)
        {
            var result = _context.Students.FirstOrDefault(c => c.Id == std.Id);
            if(result == null)
            {
                throw new UserFriendlyException($"Sinh viên có ID {std.Id} không tồn tại");
            }
            var student = _mapper.Map<Models.Student>(std);
            //result = student;
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            var result = _context.Students.FirstOrDefault(c => c.Id == id);
            if(result == null)
            {
                throw new UserFriendlyException($"Sinh viên có {id} không tồn tại");
            }
            _context.Remove(result);
            _context.SaveChanges();
        }
        public void UpdatePoint(UpdatePointDto std)
        {
            var result = _context.StudentSubjects
                            .FirstOrDefault(s => s.StudentId == std.StudentId &&  s.SubjectId == std.SubjectId);
            if (result != null)
            {
                result.Point = std.Point;
                _context.SaveChanges();
            }
            else
                throw new UserFriendlyException("Không tìm thấy sinh viên");
          
        }
        public void AddSubjectForStudent(int subjectId, int studentId)
        {
            if (_context.StudentSubjects
                .Any(sc => sc.StudentId == studentId && sc.SubjectId == subjectId))
            {
                throw new UserFriendlyException("Sinh viên đã thêm môn học");
            }
            var subject = _context.Subjects.FirstOrDefault(c => c.Id == subjectId);
            if (subject == null)
            {
                throw new UserFriendlyException("Không tìm thấy môn học");
            }
            var student = _context.Students.FirstOrDefault(c => c.Id == studentId);
            if (student == null)
            {
                throw new UserFriendlyException("Không tìm thấy sinh viên");
            }
            _context.StudentSubjects.Add(new StudentSubject
            {
                SubjectId = subjectId,
                StudentId = studentId,
            });
            _context.SaveChanges();
        }
    }
}
