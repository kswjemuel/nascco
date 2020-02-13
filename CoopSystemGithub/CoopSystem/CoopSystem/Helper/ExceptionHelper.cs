using System;

namespace CoopSystemWebApp.Helper
{
    public static class ExceptionHelper
    {
        public static String ExceptionStackTrace(Exception ex)
        {
            return ex.StackTrace;
        }

        public static string ExceptionString(Exception ex)
        {
            return string.Format("Exception Message : [ {0} ]", ex.ToString());
        }
    }
}
