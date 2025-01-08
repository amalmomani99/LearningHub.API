using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.Service
    {
    public interface IJWTService
        {
        string Auth(Login login);

        }
    }
