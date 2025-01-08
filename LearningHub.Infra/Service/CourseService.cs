using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Service
    {
    public class CourseService: ICourseService
        {
        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
            {
            this.courseRepository = courseRepository;
            }
        public List<Course> GetAllCourse()
            {
            return courseRepository.GetAllCourse();
            }
        public void CreateCourse(Course course)
            {
            courseRepository.CreateCourse(course);
            }
        public void UpdateCourse(Course course)
            {
            courseRepository.UpdateCourse(course);
            }
        public void DeleteCourse(int id)
            {
            courseRepository.DeleteCourse(id);
            }
        public Course GetByCourseId(int id)
            {
            return courseRepository.GetByCourseId(id);
            }
        public Task<List<Category>> GetAllCategoryCourse()
            {
            return courseRepository.GetAllCategoryCourse();
            }

        }
    }
