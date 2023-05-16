using JWT_test.Dto.Student;
using JWT_test.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
        [HttpGet("GetById")]
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
        [HttpPost("AddSubjectForStudent")]
        public IActionResult AddSubjectForStudent(int studentId, int subjectId)
        {
            _student.AddSubjectForStudent(subjectId, studentId);
            return Ok();
        }
        [HttpPut("UpdatePoint")]
        public IActionResult UpdatePoint(UpdatePointDto input)
        {
            _student.UpdatePoint(input);
            return Ok("Cập nhật điểm thành công");
        }
        [HttpGet("GetListPointOfStudent")]
        public IActionResult GetListPointOfStudent(int studentId)
        {
            var result = _student.GetListPointOfStudent(studentId);
            return Ok(result);
        }
        
        [HttpPost("CreateCard")]
        public IActionResult CreateCard(CardDto card)
        {
            _student.CreateCard(card);
            return Ok();
        }
        [HttpGet("getcardinfo")]
        public IActionResult getCardInfo(int id)
        {
            var result = _student.CardInfo(id);
            return Ok(result);
        }
    }
}
