using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Repository;
using LearningHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Service
    {
    public class StudentCourseService: IStudentCourseService
        {
        private readonly IStudentCourseRepository _studentCourseRepository;

        public StudentCourseService(IStudentCourseRepository studentCourseRepository)
            {
            _studentCourseRepository = studentCourseRepository;
            }
        public void CreateStudentCourse(Stdcourse studentCourse)
            {
            _studentCourseRepository.CreateStudentCourse(studentCourse);
            }

        public void DeleteStudentCourse(int id)
            {
            _studentCourseRepository.DeleteStudentCourse(id);
            }

        public List<Stdcourse> GetAllStudentCourse()
            {
            return _studentCourseRepository.GetAllStudentCourse();
            }

        public void UpdateStudentCourse(Stdcourse studentCourse)
            {
            _studentCourseRepository.UpdateStudentCourse(studentCourse);
            }
       public Stdcourse GetStudentCourseById(int id)
            {
           return _studentCourseRepository.GetStudentCourseById(id);
            }

        public List<Search> SearcheStudenCourse(Search search)
            {
            return _studentCourseRepository.SearcheStudenCourse(search);
            }

        public List<TotalStudents> TotalStudentInEachCourse()
            {
            return _studentCourseRepository.TotalStudentInEachCourse();
            }

        }
    }
