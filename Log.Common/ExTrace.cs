using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Common
{
    public class ExTrace : LogBase
    {
        public static void Assert(bool condition,string format ="", params object[] args)
        {
            if (!condition) 
                ExFail(format, args);
        }
        public static void Fail(string format, params object[] args)
            => ExFail(format, args);
        public static void Error(Exception ex, string format="",params object[] args)
            => ExFail($"{format}{Environment.NewLine}{ex}", args);
        public static void Print(string format, params object[] args)
            =>ExPrint(format, args);
        public static void PrintIf(bool condition, string format, params object[] messages)
        {
            if (!condition) ExPrint(format, messages);
        }

        /// <summary>Prints warning logs.</summary>
        /// <param name="format">Message format</param>
        /// <param name="messages">Messages</param>
        public static void Warning(string format, params object[] messages) => ExPrint(format, messages);

        /// <summary>Prints warning logs, if the condition is <c>true</c>.</summary>
        /// <param name="condition">Condition.</param>
        /// <param name="format">Message format</param>
        /// <param name="messages">Messages</param>
        public static void WarningIf(bool condition, string format, params object[] messages)
        {
            if (!condition) ExPrint(format, messages);
        }
    }
}
