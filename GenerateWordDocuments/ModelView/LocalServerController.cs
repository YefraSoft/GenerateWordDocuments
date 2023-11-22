using GenerateWordDocuments.Model;
using System;
using System.Data;
using System.Windows.Markup;

namespace GenerateWordDocuments.ModelView
{
    static class ServersController
    {
        /* USER VALIDATION */
        public static int VerifyUser(string user, string pass)
        {
            var (permiss, code) = ConectionMySql.ConecctionUser(user, pass);
            int permission = 0;
            if (!string.IsNullOrEmpty(permiss)) {
                if (permiss.Length < 300)
                {
                    permission = 2;
                }
                else
                {
                    permission = 1;
                }
                CurrentUser._TEACHERCODE = code;
                CurrentUser._USER = user;
                CurrentUser._PASS = pass;
            }
            return permission;
        }

        /* USER STORED PROCEDURE */
        public static DataSet GetUser()
        {
            DataSet data = new();
            return ConectionMySql.GetUser(data, CurrentUser._TEACHERCODE.ToString());
        }
        public static DataSet GetUser(string code)
        {
            DataSet data = new();
            return ConectionMySql.GetUser(data, code);
        }
        public static string GetPass(int code)
        {
            return ConectionMySql.RecoverPass(code, CurrentUser._WILDNUSER, CurrentUser._WILDPASS);
        }
        public static bool UpdateCredentials(string user, string pass)
        {
            bool res = false;
            if (ConectionMySql.UpdateCredentials(CurrentUser._TEACHERCODE,user,pass) == 202)
            {
                res = true;
            }
            return res;
        }
        public static bool ChangePass(string pass)
        {
            bool res = false;
            if (ConectionMySql.ChangePassword(CurrentUser._TEACHERCODE, pass) == 202)
            {
                res = true;
            }
            return res;
        }

        /* ADMIN PROCEDURES */
        public static DataSet GetUsersAdmin()
        {
            DataSet data = new();
            return ConectionMySql.GetUsers(data);
        }
        public static DataSet GetUser(string code,string user,string pass)
        {
            DataSet data = new();
            return ConectionMySql.GetUser(data, code, user, pass);
        }


        /* CRUD ADMIN */
        public static bool AddTeacher(string _code, string _name, string _pSur, string _mSur, string _mat)
        {
            bool res = false;
            if (ConectionMySql.AddTeacher(_code,_name,_pSur,_mSur,_mat) == 0)
            {
                res = true;
            }
            return res;
        }
        public static bool ModifyTeacher(string _code, string _name, string _pSur, string _mSur, string _mat)
        {
            bool res = false;
            if (ConectionMySql.EditTeacher(_code, _name, _pSur, _mSur, _mat) > 0)
            {
                res = true;
            }
            return res;
        }
        public static bool DropTeacher(string _code)
        {
            bool res = false;
            if (ConectionMySql.DropTeacher(_code) > 0)
            {
                res = true;
            }
            return res;
        }
    }
}
