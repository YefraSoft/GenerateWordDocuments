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
        public static string _CREATEUSERQUERRY(string user,string pass)
        {
            return "CREATE USER '" + user + "'@'%' IDENTIFIED BY '" + pass + "';";
        }
        public static string _POSTPERMISSIONINSERT(string user) {
            return "GRANT SELECT ON documentcreator.teachers TO '" + user + "';";
        }
        public static string _POSTPERMISSIONSELECT(string user) {
            return "GRANT INSERT ON documentcreator.documentiformation TO '" + user + "';";
        }
        public static string _GETUSERSADMIN()
        {
            return "CALL GetDatesOfTeachers;";
        }

        public static string _GETTEACHERVALUES(string _employecode)
        {
            return "SELECT * FROM documentcreator.teachers WHERE documentcreator.teachers._teacherCode = " + _employecode + ";";
        }
        public static string _CREATESTRINGCONECCTION(string user, string pass)
        {
            _USER = "User=" + user + ";";
            _PASSWORD = "Password=" + pass + ";";
            return (_HOST + _USER + _PASSWORD + _DATABASE);
        }
    }
}
