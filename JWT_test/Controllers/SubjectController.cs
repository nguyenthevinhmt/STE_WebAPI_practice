using JWT_test.Dto.Subject;
using JWT_test.Models;
using JWT_test.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _subject;
        public SubjectController(ISubject subject)
        {
            _subject = subject;
        }
        [HttpGet]
        public IActionResult GetAll() {
            var result = _subject.GetAll();
            return Ok(result);
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
                var result = _subject.GetById(id);
                return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateSubject(CreateSubjectDto sub)
        {
            _subject.CreateSubject(sub);
            return Ok("thêm thành công");        
        }
        [HttpPut]
        public IActionResult UpdateSubject(ResponeSubjectDto sub)
        {
                _subject.UpdateSubjects(sub);
                return Ok("Cập nhật thành công");         
        }
        [HttpDelete]
        public IActionResult DeleteSubject(int id)
        {           
            _subject.DeleteSubjects(id);
            return Ok("Xóa thành công");           
        }
    }
}
