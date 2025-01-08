using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Service
    {
    public interface ICourseService
        {
        List<Course> GetAllCourse();
        void CreateCourse(Course course);
        void DeleteCourse(int id);
        public void UpdateCourse(Course course);
        Course GetByCourseId(int id);
        Task<List<Category>> GetAllCategoryCourse();

        }
    }
