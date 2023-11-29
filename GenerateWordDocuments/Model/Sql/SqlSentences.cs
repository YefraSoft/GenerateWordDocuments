using System.Windows.Controls.Primitives;

namespace GenerateWordDocuments.Model.Sql
{
    public static class SqlSentences
    {
        const string _HOST = "Server=127.0.0.1;";
        static string? _USER;
        static string? _PASSWORD;
        const string _DATABASE = "Database=Documentcreator;";

        public static string _GETPERMISSIONS(string user) {
            return "SHOW GRANTS FOR '" + user + "';";
        }
        public static string _GETUSERSINFO()
        {
            return "CALL documentcreator.GetDatesOfTeachers;";
        }

        public static string _GETTEACHERCODE()
        {
            return "GetEmployeCode";
        }
        public static string _RECOVERPASSWORD()
        {
            return "RecoverPass";
        }
        public static string _UPDATECREDENTIALS()
        {
            return "updateCredentials";
        }
        public static string _CHANGEPASSWORD()
        {
            return "ChangePassword";
        }

        public static string _GETUSERINFO(string _code)
        {
            return "CALL ConsultTeacher(" + _code + ")" + ";";
        }

        public static string _ADDTEACHER(string _code, string _name, string _pSur, string _mSur, string _mat)
        {
            return "CALL documentcreator.AddDocent(" + _code + ", '" + _name + "', '" + _pSur + "', '" + _mSur + "', '" + _mat + "');";
        }
        public static string _MODIFYTEACHER(string _code, string _name, string _pSur, string _mSur, string _mat)
        {
            return "CALL documentcreator.ModifyDocent(" + _code + ", '" + _name + "', '" + _pSur + "', '" + _mSur + "', '" + _mat + "');";
        }
        public static string _DROPTEACHER(string _code)
        {
            return "CALL documentcreator.DropTeacher(" + _code + ");";
        }
        public static string _CREATEINCIDENT(string _code,string _reazon,string _why,string _date)
        {
            return "INSERT INTO documentcreator.documentiformation (_teacherCode,_reason,_why,_Date) VALUES (" + _code + ", '" + _reazon + "', '" + _why + "', '" + _date + "');";
        }
        public static string _GETREPORTS()
        {
            return "SELECT * FROM documentcreator.documentiformation;";
        }
        public static string _CREATELOGIN()
        {
            return "CALL documentcreator.CreateLogin();";
        }
        public static string _GETNAMETEACHER(string code)
        {
            return "SELECT CONCAT(_name,\" \",_paternalSurname,\" \",_maternalSurname) AS nombre FROM documentcreator.teachers WHERE _teacherCode = " + code + ";";
        }
        public static string _GETMATTERTEACHER(string code)
        {
            return "SELECT _matter FROM documentcreator.teachers WHERE _teacherCode = " + code + ";";
        }
        public static string _CREATESTRINGCONECCTION(string user, string pass)
        {
            _USER = "User=" + user + ";";
            _PASSWORD = "Password=" + pass + ";";
            return (_HOST + _USER + _PASSWORD + _DATABASE);
        }
    }
}
