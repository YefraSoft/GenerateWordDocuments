using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateWordDocuments.ModelView
{
    public static class CurrentUser
    {
        public static string _WILDNUSER = "wildcard";
        public static string _WILDPASS = "PASSWORD"; 
        public static int _TEACHERCODE { get; set; }
        private static string user = "";
        private static string pass = "";
        public static string _USER { get => user; set { user = value; } }
        public static string _PASS { get => pass; set { pass = value; } }
    }
}
