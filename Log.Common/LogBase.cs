using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Common
{
    public class LogBase
    {
        private const string FileExtension =  ".log";
        private static readonly string _lineIndent =  $"{Environment.NewLine}\t\t\t\t\t";
        private static string? _fileName;

        private static int _logStackFrame;
        private static int _callerStackFrame;

        public static FileMode FileMode { get; set; } = FileMode.Create;
        public static string LogLineHeaderFormat { get; set; } = "{0:yy-MM-dd HH:mm:ss.ffff}\t{1}\t{2}\t{3}\t{4}()\t";

        public static void AddFileListener(string? fileName = null)
        {
            _fileName = fileName ?? AppDomain.CurrentDomain.BaseDirectory + "\\"
                + AppDomain.CurrentDomain.FriendlyName + FileExtension;
            try
            {
                if (FileMode is FileMode.Create && File.Exists(_fileName)) 
                    File.Delete(_fileName);
                using var file = File.Open(_fileName, FileMode);
            }
            catch 
            {
                Trace.TraceWarning(Texts.FileNot, _fileName);
                throw;
            }
        }
        protected static void ExFail(string? format, params object[] args)
            => Trace.Fail(PritLog(format, args));
        protected static void ExPrint(string? format, params object[] args)
            =>Trace.WriteLine(PritLog($"{format}", args));

        private static string? PritLog(string format, object[] args)
        {
            var stackTrace = new StackTrace();
            if(_logStackFrame== 0)
            {
                for(var i = 1; i < stackTrace.FrameCount; i++ )
                {
                    var className = stackTrace.GetFrame(i)?.GetMethod()?.DeclaringType?.Name;
                    if(className is (nameof(ExTrace)) or (nameof(ExDebug)))
                    {
                        _logStackFrame = i;
                        _callerStackFrame = i + 1;
                    }                        
                }
            }
            var log = stackTrace.GetFrame(_logStackFrame)?.GetMethod();
            var caller = stackTrace.GetFrame(_callerStackFrame)?.GetMethod();
            var text = new StringBuilder()
                .AppendFormat(LogLineHeaderFormat, DateTime.Now,
                    log?.DeclaringType?.Name, log?.Name, caller?.DeclaringType?.Name, caller?.Name)
                .AppendFormat(format,args).Replace(Environment.NewLine,_lineIndent);

            if(_fileName is not null)
                File.AppendAllText(_fileName,text.ToString() + Environment.NewLine);
            return text.ToString();
        }
    }
}
