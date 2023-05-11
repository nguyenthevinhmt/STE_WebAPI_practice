using JWT_test.Dto.Student;
using JWT_test.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JWT_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudents _student;

        public StudentsController(IStudents student)
        {
            _student = student;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _student.GetAll();
            return Ok(result);
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {

            var result = _student.GetById(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult CreateStudent(CreateStudentDto std)
        {
            _student.CreateStudent(std);
            return Ok("thêm thành công");
        }
        [HttpPut]
        public IActionResult UpdateStudent(ResponeStudentDto std)
        {

            _student.UpdateStudent(std);
            return Ok("Cập nhật thành công");

        }
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            _student.DeleteStudent(id);
            return Ok("Xóa thành công");
        }
        [HttpPost("AddPointForStudent")]
        public IActionResult AddSubjectForStudent(int studentId, int subjectId)
        {
            _student.AddSubjectForStudent(subjectId, studentId);
            return Ok();
        }
        [HttpPost("UpdatePoint")]
        public IActionResult UpdatePoint(UpdatePointDto input)
        {
            var result = _student.UpdatePoint(input);    
            return Ok(result);
        }
    }
}
