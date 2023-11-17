using System;
using System.Configuration;
using System.Text;

namespace GenerateWordDocuments.Model.Sql
{
    static class GetConectionString
    {
        public static string DeCrypt()
        {
            return Encoding.Unicode.GetString(Convert.FromBase64String(ConfigurationManager.ConnectionStrings["MysqlConection"].ConnectionString));
        }
    }
}
