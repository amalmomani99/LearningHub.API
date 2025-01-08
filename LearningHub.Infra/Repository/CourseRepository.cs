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
    public class CourseRepository : ICourseRepository
    {
        private readonly IDBContext dBContext;

        public CourseRepository(IDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public List<Course> GetAllCourse()
        {
            IEnumerable<Course> result = dBContext.Connection.Query<Course>("Course_Package.GetAllCourses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public void CreateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("COURSENAME", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dBContext.Connection.Execute("Course_Package.CREATECOURSE", p, commandType: CommandType.StoredProcedure);

        }


        public void UpdateCourse(Course course)
        {
            var p = new DynamicParameters();
            p.Add("ID", course.Courseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("CNAME", course.Coursename, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CATID", course.Categoryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image", course.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dBContext.Connection.Execute("Course_Package.UPDATECOURSE", p, commandType: CommandType.StoredProcedure);
        }


        public void DeleteCourse(int id)
        {
            var p = new DynamicParameters();
            p.Add("Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dBContext.Connection.Execute("Course_Package.DeleteCourse", p, commandType: CommandType.StoredProcedure);
        }

        public Course GetByCourseId(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Course> result = dBContext.Connection.Query<Course>("Course_Package.GetCourseById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public async Task<List<Category>> GetAllCategoryCourse()
            {
            var p = new DynamicParameters();
            var result = await dBContext.Connection.QueryAsync<Category, Course, Category>("Course_Package.GetAllCategoryCourse",
            (Category, course) =>
            {
                Category.Courses.Add(course);
                return Category;
            },
 splitOn: "Courseid",
            param: null,
            commandType: CommandType.StoredProcedure

            );
            var results = result.GroupBy(p => p.Categoryid).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Courses = g.Select(p => p.Courses.Single()).ToList();
                return groupedPost;
            });
            return results.ToList();
            }

        }

    }

