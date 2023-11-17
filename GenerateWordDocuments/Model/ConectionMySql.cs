using GenerateWordDocuments.Model.Sql;
using MySql.Data.MySqlClient;
using System.Data;

namespace GenerateWordDocuments.Model
{
    static class ConectionMySql
    {
        public static string? ConecctionUser(string user, string pass)
        {
            string? permision = null;
            using MySqlConnection con = new(SqlSentences._CREATESTRINGCONECCTION(user, pass));
            try {
                con.Open();
                if (con.State == ConnectionState.Open) {
                    using MySqlCommand adapter = new(SqlSentences._GETPERMISSIONS(user), con);
                    permision = adapter.ExecuteScalar().ToString();
                }
            } catch {
            }
            return permision;
            
        }
        public static bool? CreateUser(string user, string pass)
        {
            bool? userExist = null;
            using MySqlConnection con = new(GetConectionString.DeCrypt());
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    using MySqlCommand cmd = new(SqlSentences._CREATEUSERQUERRY(user, pass), con);
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        userExist = true;
                    }
                }
            }
            catch
            {
                userExist = false;
            }
            return userExist;
        }
        public static DataSet GetUsers(DataSet dataSet)
        {
            
            using MySqlConnection con = new(GetConectionString.DeCrypt());
            try
            {
                con.Open();
                using MySqlDataAdapter adapter = new(SqlSentences._GETUSERSADMIN(), con);
                adapter.Fill(dataSet);
            }
            catch
            {

            }
            return dataSet;
        }
    }
}
