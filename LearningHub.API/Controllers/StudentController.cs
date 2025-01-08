using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
        {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService Istdservice)
            {
            this._studentService = Istdservice;
            }


        [HttpGet]
        public List<Student> GetAllStudent()
            {
            return _studentService.GetAllStudent();
            }

        [HttpPost]
        public void CreateStudent(Student Student)
            {
            _studentService.CreateStudent(Student);
            }

        [HttpPut]
        public void UpdateStudent(Student Student)
            {
            _studentService.UpdateStudent(Student);
            }

        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteStudent(int id)
            {
            _studentService.DeleteStudent(id);
            }
        [HttpGet]
        [Route("getByStudentId/{id}")]
        public Student GetStudentById(int id)
            {
            return _studentService.GetStudentById(id);
            }

        [HttpGet]
        [Route("GetStduentByFName/{name}")]
        public List<Student> GetStudentByFName(string name)
            {
            return _studentService.GetStudentByFName(name);
            }

        [HttpGet]
        [Route("GetStduentFNameAndLName")]
        public List<Student> GetStudentFNameAndLName()
            {
            return _studentService.GetStudentFNameAndLName();
            }

        [HttpGet]
        [Route("GetStudentByBirthdate/{Birth_Date}")]
        public List<Student> GetStudentByBirthdate(DateTime Birth_Date)
            {
            return _studentService.GetStudentByBirthdate(Birth_Date);
            }
        [HttpGet]
        [Route("GetStudentBetweenDate/{DateFrom}/{DateTo}")]
        public List<Student> GetStudentBetweenDate(DateTime DateFrom, DateTime DateTo)
            {
            return _studentService.GetStudentBetweenDate(DateFrom, DateTo);
            }
        [HttpGet]
        [Route("GetStudentsWithHighestMarks/{numOfStudent}")]
        public List<Student> GetStudentsWithHighestMarks(int numOfStudent)
            {
            return _studentService.GetStudentsWithHighestMarks(numOfStudent);
            }


        }
    }
