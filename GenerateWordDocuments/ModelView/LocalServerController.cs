using GenerateWordDocuments.Model;
using System.Data;

namespace GenerateWordDocuments.ModelView
{
    static class ServersController
    {
        public static int VerifyUser(string user, string pass)
        {
            var res = ConectionMySql.ConecctionUser(user, pass);
            int permission = 0;
            if (!string.IsNullOrEmpty(res)) {
                if (res.Length < 300)
                {
                    permission = 2;
                }
                else
                {
                    permission = 1;
                }
            }
            return permission;
        }
        public static bool? CreateUser(string user, string pass)
        {
            return ConectionMySql.CreateUser(user, pass);
        }
        public static DataSet GetUsersAdmin()
        {
            DataSet data = new();
            return ConectionMySql.GetUsers(data);
        }
    }
}
