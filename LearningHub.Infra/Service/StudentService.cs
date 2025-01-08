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
    public class StudentService : IStudentService
        {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
            {
            _studentRepository = studentRepository;
            }
        public List<Student> GetAllStudent()
            {
            return _studentRepository.GetAllStudent();
            }
        public void CreateStudent(Student Student)
            {
            _studentRepository.CreateStudent(Student);
            }
        public void UpdateStudent(Student Student)
            {
            _studentRepository.UpdateStudent(Student);
            }
        public void DeleteStudent(int id)
            {
            _studentRepository.DeleteStudent(id);
            }
        public Student GetStudentById(int id)
            {
            return _studentRepository.GetStudentById(id);
            }
        public List<Student> GetStudentByFName(string name)
            {
            return _studentRepository.GetStudentByFName(name);
            }

        public List<Student> GetStudentFNameAndLName()
            {
            return _studentRepository.GetStudentFNameAndLName();
            }
        public List<Student> GetStudentByBirthdate(DateTime Birth_Date)
            {
            return _studentRepository.GetStudentByBirthdate(Birth_Date);
            }
        public List<Student> GetStudentBetweenDate(DateTime DateFrom, DateTime DateTo)
            {
            return _studentRepository.GetStudentBetweenDate(DateFrom, DateTo);
            }
        public List<Student> GetStudentsWithHighestMarks(int numOfStudent)
            {
            return _studentRepository.GetStudentsWithHighestMarks(numOfStudent);
            }

        }
    }
