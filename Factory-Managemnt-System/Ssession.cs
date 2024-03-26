using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Managemnt_System
{
    public static class Session
    {
        public static string CurrentUser { get; private set; }
        public static string CurrentUserRole { get; private set; }

        public static void StartSession(string username, string role)
        {
            CurrentUser = username;
            CurrentUserRole = role;
        }

        public static void EndSession()
        {
            CurrentUser = null;
            CurrentUserRole = null;
        }
    }

}
