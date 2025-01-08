using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
        {
        private readonly IStudentCourseService _studentCourseService;

        public StudentCourseController(IStudentCourseService studentCourseService)
            {
            _studentCourseService = studentCourseService;
        }

        [HttpGet]
        public List<Stdcourse> GetAllStudentCourse()
            {
            return _studentCourseService.GetAllStudentCourse();
            }

        [HttpPost]
        public void CreateStudentCourse(Stdcourse studentCourse)
            {
            _studentCourseService.CreateStudentCourse(studentCourse);
            }



        [HttpPut]
        public void UpdateStudentCourse(Stdcourse studentCourse)
            {
            _studentCourseService.UpdateStudentCourse(studentCourse);
            }


        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteStudentCourse(int id)
            {
            _studentCourseService.DeleteStudentCourse(id);
            }

        [HttpGet]
        [Route("getStudentCourseById/{id}")]
        public Stdcourse GetStudentCourseById(int id)
            {
            return _studentCourseService.GetStudentCourseById(id);
            }

        [HttpPost]
        [Route("SearchStudenCourse")]
        public List<Search> SearcheStudenCourse(Search search)
            {
            return _studentCourseService.SearcheStudenCourse(search);
            }

        [HttpGet]
        [Route("TotalStudentInEachCourse")]
        public List<TotalStudents> TotalStudentInEachCourse()
            {
            return _studentCourseService.TotalStudentInEachCourse();
            }


        }
    }
