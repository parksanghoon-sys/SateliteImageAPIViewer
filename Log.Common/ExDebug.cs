﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Common
{
    public class ExDebug : LogBase
    {
        [Conditional("DEBUG")]
        public static void Assert(bool condition, string format = "", params object[] messages)
        {
            if (!condition) ExFail(format, messages);
        }

        /// <summary>the message are displayed in a message box and exits.</summary>
        /// <param name="format">Message format</param>
        /// <param name="messages">Messages</param>
        [Conditional("DEBUG")]
        public static void Fail(string format, params object[] messages) => ExFail(format, messages);

        /// <summary>the message and exception are displayed in a message box and exits.</summary>
        /// <param name="ex">Exception.</param>
        /// <param name="format">Message format</param>
        /// <param name="messages">Messages</param>
        [Conditional("DEBUG")]
        public static void Error(Exception ex, string format = "", params object[] messages)
             => ExFail($"{format}{Environment.NewLine}{ex}", messages);

        [Conditional("DEBUG")]
        public static void Print(string format, params object[] messages) => ExPrint(format, messages);

        [Conditional("DEBUG")]
        public static void PrintIf(bool condition, string format, params object[] messages)
        {
            if (!condition) ExPrint(format, messages);
        }

        [Conditional("DEBUG")]
        public static void Warning(string format, params object[] messages) => ExPrint(format, messages);


        [Conditional("DEBUG")]
        public static void WarningIf(bool condition, string format, params object[] messages)
        {
            if (!condition) ExPrint(format, messages);
        }
    }
}
