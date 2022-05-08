using System;

namespace task_tracker.DAL.Common.Extensions
{
    public static class StringExtensions
    {
        public static int AsInt(this string number)
        {
            return Convert.ToInt32(number);
        }
    }
}