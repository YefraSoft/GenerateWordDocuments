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
        public static string? _USER { get; set; }
        public static string? _PASS { get; set; }
    }
}
