using GenerateWordDocuments.Model.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing.Imaging;
using System.IO.Packaging;
using System.Windows;

namespace GenerateWordDocuments.Model
{
    static class ConectionMySql
    {
        private static string conection = "";

        /* USER VALIDATION */
        public static (string?, int) ConecctionUser(string user, string pass)
        {
            string? permision = null;
            int codeTeacher = 0;
            conection = SqlSentences._CREATESTRINGCONECCTION(user, pass);
            using MySqlConnection con = new(conection);
            try {
                con.Open();
                if (con.State == ConnectionState.Open) {
                    using MySqlCommand adapter = new(SqlSentences._GETPERMISSIONS(user), con);
                    permision = adapter.ExecuteScalar().ToString();

                    using MySqlCommand adapter2 = new(SqlSentences._GETTEACHERCODE(), con);
                    adapter2.CommandType = CommandType.StoredProcedure;
                    adapter2.Parameters.AddWithValue("_userN",user);

                    MySqlParameter parameter = new("_code", MySqlDbType.Int32);;
                    parameter.Direction = ParameterDirection.Output;
                    adapter2.Parameters.Add(parameter);
                    adapter2.ExecuteNonQuery();
                    codeTeacher = (int)parameter.Value;
                }
            } catch {
                conection = "";
            }
            return (permision, codeTeacher);
            
        }
        /*public static bool? CreateUser(string user, string pass)
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
        }*/
        
        /* USER STORED PROCEDURE */
        public static string RecoverPass(int code,string user,string passw)
        {
            string pass = "";
            using MySqlConnection con = new(SqlSentences._CREATESTRINGCONECCTION(user, passw));
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    using MySqlCommand command = new(SqlSentences._RECOVERPASSWORD(), con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("_code", code);

                    MySqlParameter parameter = new("_pass", MySqlDbType.VarChar, 25);
                    parameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                    pass = (string)parameter.Value;
                }
            }
            catch
            {
            }
            return pass;
        }
        public static int UpdateCredentials(int code,string user,string pass)
        {
            int res = 0;
            using MySqlConnection con = new(conection);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    using MySqlCommand command = new(SqlSentences._UPDATECREDENTIALS(), con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("_code", code);
                    command.Parameters.AddWithValue("_userN", user);
                    command.Parameters.AddWithValue("_passN", pass);

                    MySqlParameter parameter = new("_res", MySqlDbType.Int32);
                    parameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                    res = (int)parameter.Value;
                }
            }
            catch
            {
            }
            return res;
        }
        public static int ChangePassword(int code, string pass)
        {
            int res = 0;
            using MySqlConnection con = new(conection);
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    using MySqlCommand command = new(SqlSentences._CHANGEPASSWORD(), con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("_code", code);
                    command.Parameters.AddWithValue("_passN", pass);

                    MySqlParameter parameter = new("_res", MySqlDbType.Int32);
                    parameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                    res = (int)parameter.Value;
                }
            }
            catch
            {
            }
            return res;
        }
        public static DataSet GetUser(DataSet dataSet, string _code, string user, string pass)
        {
            using MySqlConnection con = new(SqlSentences._CREATESTRINGCONECCTION(user, pass));
            try
            {
                con.Open();
                using MySqlDataAdapter adapter = new(SqlSentences._GETUSERINFO(_code), con);
                adapter.Fill(dataSet);
            }
            catch
            {
            }
            return dataSet;
        }

        /* ADMIN PROCEDURES */
        public static DataSet GetUsers(DataSet dataSet)
        {
            using MySqlConnection con = new(GetConectionString.DeCrypt());
            try
            {
                con.Open();
                using MySqlDataAdapter adapter = new(SqlSentences._GETUSERSINFO(), con);
                adapter.Fill(dataSet);
            }
            catch
            {
            }
            return dataSet;
        }
        
        /* CRUD ADMIN */
        public static int AddTeacher(string _code,string _name,string _pSur,string _mSur,string _mat)
        {
            int res = 0;
            using MySqlConnection conn = new(GetConectionString.DeCrypt());
            try {
                conn.Open();
                using MySqlCommand sqlCommand = new(SqlSentences._ADDTEACHER(_code, _name, _pSur, _mSur, _mat), conn);
                if(sqlCommand.ExecuteNonQuery() > 0)
                {
                    using MySqlCommand CommandLog = new(SqlSentences._CREATELOGIN(), conn);
                    CommandLog.ExecuteNonQuery();
                }
            }
            catch { }
            return res;
        }
        public static int EditTeacher(string _code, string _name, string _pSur, string _mSur, string _mat)
        {
            int res = 0;
            using MySqlConnection conn = new(GetConectionString.DeCrypt());
            try
            {
                conn.Open();
                using MySqlCommand sqlCommand = new(SqlSentences._MODIFYTEACHER(_code, _name, _pSur, _mSur, _mat), conn);
                res = sqlCommand.ExecuteNonQuery();
            }catch { }
            return res;
        }
        public static int DropTeacher(string _code)
        {
            int res = 0;
            using MySqlConnection conn = new(GetConectionString.DeCrypt());
            try
            {
                conn.Open();
                using MySqlCommand sqlCommand = new(SqlSentences._DROPTEACHER(_code), conn);
                res = sqlCommand.ExecuteNonQuery();
            }
            catch { }
            return res;
        }
    }
}
