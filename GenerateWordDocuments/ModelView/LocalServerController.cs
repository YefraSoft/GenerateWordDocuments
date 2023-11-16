using GenerateWordDocuments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateWordDocuments.ModelView
{
    static class SqlServerController
    {
        public static bool? VerifyUser(string user, string pass)
        {
            return ConectionMySql.ConecctionUser(user, pass);
        }
    }
}
