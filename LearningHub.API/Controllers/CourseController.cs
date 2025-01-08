using LearningHub.Core.Data;
using LearningHub.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
        {
        private readonly ICourseService courseService;

        public CourseController(ICourseService courseService)
            {
            this.courseService = courseService;
            }
        [HttpGet]
        public List<Course> GetAllCourse()
            {
            return courseService.GetAllCourse();
            }


        [HttpPost]
        public void CreateCourse(Course course)
            {
            courseService.CreateCourse(course);
            }

        [HttpPut]
        public void UpdateCourse(Course course)

            {
            courseService.UpdateCourse(course);
            }


        [HttpDelete]
        [Route("delete/{id}")]
        public void DeleteCourse(int id)
            {
            courseService.DeleteCourse(id);
            }

        [HttpGet]
        [Route("getByCourseId/{id}")]
        public Course GetByCourseId(int id)
            {
            return courseService.GetByCourseId(id);
            }
        [Route("uploadImage")]
        [HttpPost]
        public Course UploadIMage()
            {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                file.CopyTo(stream);
                }
            Course item = new Course();
            item.Imagename = fileName;
            return item;
            }

        [HttpGet]
        [Route("GetAllCategoryCourse")]
        public Task<List<Category>> GetAllCategoryCourse()
            {
            return courseService.GetAllCategoryCourse();

            }

        }
    }
