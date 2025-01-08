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
    public class JWTRepository: IJWTRepository
        {
        private readonly IDBContext dBContext;

        public JWTRepository(IDBContext dBContext)
            {
            this.dBContext = dBContext;
            }
        public Login Auth(Login login)
            {

            var p = new DynamicParameters();
            p.Add("User_NAME", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result = dBContext.Connection.Query<Login>("Login_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
            }

        }
    }
