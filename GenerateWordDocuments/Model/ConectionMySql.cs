

using MySql.Data.MySqlClient;
using System.Data;

namespace GenerateWordDocuments.Model
{
    static class ConectionMySql
    {
        private static string _HOST = "Server=127.0.0.1;";
        private static string? _USER;
        private static string? _PASSWORD;
        private static string _DATABASE = "Database=Documentcreator;";

        public static bool? ConecctionUser(string user, string pass)
        {
            bool? userExist = null;
            _USER = "User=" + user + ";";
            _PASSWORD = "Password=" + pass + ";";
            MySqlConnection con = new(_HOST + _USER + _PASSWORD + _DATABASE);
            try {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    userExist = true;
                }
                
            } catch {
                userExist = false;
            }
            return userExist;
            
        }
    }
}
