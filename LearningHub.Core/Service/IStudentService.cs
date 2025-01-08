﻿using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Service
    {
    public interface IStudentService
        {
        List<Student> GetAllStudent();
        void CreateStudent(Student Student);
        void UpdateStudent(Student Student);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Student> GetStudentByFName(string name);
        List<Student> GetStudentFNameAndLName();
        List<Student> GetStudentByBirthdate(DateTime Birth_Date);
        List<Student> GetStudentBetweenDate(DateTime DateFrom, DateTime DateTo);
        List<Student> GetStudentsWithHighestMarks(int numOfStudent);

        }
    }
