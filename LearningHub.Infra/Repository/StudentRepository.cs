using Dapper;
using LearningHub.Core.Common;
using LearningHub.Core.Data;
using LearningHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDBContext dBContext;

        public StudentRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public List<Student> GetAllStudent()
        {
            IEnumerable<Student> result = dBContext.Connection.Query<Student>("Student_Package.GetAllStudent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void CreateStudent(Student Student)
        {
            var p = new DynamicParameters();
            p.Add("first_name", Student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("last_name", Student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("date_of_birth", Student.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("Student_Package.CreateStudent", p, commandType: CommandType.StoredProcedure);
        }


        public void UpdateStudent(Student Student)
        {
            var p = new DynamicParameters();
            p.Add("ID", Student.Studentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("first_name", Student.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("last_name", Student.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("date_of_birth", Student.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("Student_Package.UpdateStudent", p, commandType: CommandType.StoredProcedure);
        }


        public void DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.ExecuteAsync("Student_Package.DeleteStudent", p, commandType: CommandType.StoredProcedure);
        }

        public Student GetStudentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dBContext.Connection.Query<Student>("Student_Package.GetStudentById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public List<Student> GetStudentByFName(string name)
        {
            var p = new DynamicParameters();
            p.Add("First_Name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dBContext.Connection.Query<Student>("Student_Package.GetStudentByFirstName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetStudentFNameAndLName()
        {
            IEnumerable<Student> result = dBContext.Connection.Query<Student>("Student_Package.GetStudentFNameAndLName", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Student> GetStudentByBirthdate(DateTime Birth_Date)
        {
            var p = new DynamicParameters();
            p.Add("Birth_Date", Birth_Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dBContext.Connection.Query<Student>("Student_Package.GetStudentByBirthdate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<Student> GetStudentBetweenDate(DateTime DateFrom, DateTime DateTo)
        {
            var p = new DynamicParameters();
            p.Add("DateFrom", DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("DateTo", DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dBContext.Connection.Query<Student>("Student_Package.GetStudentBetweenInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<Student> GetStudentsWithHighestMarks(int numOfStudent)
        {
            var p = new DynamicParameters();
            p.Add("NumOfStudent", numOfStudent, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Student> result = dBContext.Connection.Query<Student>("Student_Package.GetStudentsWithHighestMarks", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }

}