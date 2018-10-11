using log4net.Config;
using log4net.Core;
using log4net.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Logs
{

    /// <summary>
    /// Implementation of <see cref="System.Diagnostics.TraceListener" /> with log4net
    /// </summary>
    public class Log4NetTraceListener : System.Diagnostics.TraceListener
    {

        static Log4NetTraceListener()
        {
            Log4NetTraceListener._sessionId = Guid.NewGuid().ToString();
        }
        
        /// <summary>
        /// Initialize log with log4net
        /// </summary>
        /// <param name="name"></param>
        /// <param name="log4NetconfigPath"></param>
        public static Log4NetTraceListener Initialize(string name, string log4NetconfigPath = "Log4Net.config")
        {
            AssemblyLogger.Initialize();
            Log4NetTraceListener log = new Log4NetTraceListener(name, log4NetconfigPath);
            System.Diagnostics.Trace.Listeners.Add(log);
            return log;
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._logger.Repository.GetAppenders().ToList().ForEach(c => ((log4net.Appender.AppenderSkeleton)c).Flush(50000));
            Trace.Listeners.Remove(this);
        }

        private Log4NetTraceListener(string name, string log4NetconfigPath)
        {

            Name = name;
            Assembly assembly = typeof(Log4NetTraceListener).Assembly;

            _logger = LoggerManager.GetLogger(assembly, name);
            _repository = _logger.Repository;

            var file = new FileInfo(log4NetconfigPath);
            if (file.Exists)
            {
                XmlConfigurator.Configure(_repository, file);
            }

            LogInternal(Level.Info, "Log initialized", new List<KeyValuePair<string, object>>());

        }

        /// <summary>
        /// Add a new track level on the log
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        public static void AddLevel(int value, string name, string displayName)
        {
            LogLevel.AddLevel(value, name, displayName);
        }

        public override void Write(string message)
        {
            WriteLine(message);
        }

        public override void WriteLine(string message)
        {
            LogInternal(Level.Info, message, new List<KeyValuePair<string, object>>());
        }

        public override void Write(object o)
        {
            WriteLine(o);
        }

        public override void Write(object o, string category)
        {
            if (o is Exception e)
                LogInternal(category.ConvertLevel(), e.Message, e, new List<KeyValuePair<string, object>>());

            else
            {
                var p = GetParameters(o, out string msg);
                LogInternal(category.ConvertLevel(), msg, p);
            }
        }

        public override void Write(string message, string category)
        {
            WriteLine(message, category);
        }

        public override void WriteLine(object o, string category)
        {
            if (o is Exception e)
                LogInternal(category.ConvertLevel(), e.Message, e, new List<KeyValuePair<string, object>>());

            else
            {
                var p = GetParameters(o, out string msg);
                LogInternal(category.ConvertLevel(), msg, p);
            }
        }

        public override void WriteLine(string message, string category)
        {
            LogInternal(category.ConvertLevel(), message, new List<KeyValuePair<string, object>>());
        }

        public override void WriteLine(object o)
        {
            if (o is Exception e)
                LogInternal(Level.Info, e.Message, e, new List<KeyValuePair<string, object>>());

            else
            {
                var p = GetParameters(o, out string msg);
                LogInternal(Level.Info, msg, p);
            }

        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public List<KeyValuePair<string, object>> GetParameters(object parameters, out string message)
        {

            var dic = parameters.GetDictionnaryProperties(false);

            List<KeyValuePair<string, object>> _parameters = new List<KeyValuePair<string, object>>();

            message = string.Empty;

            foreach (var item in dic)
            {

                switch (item.Key.ToLower())
                {

                    case "text":
                    case "txt":
                    case "message":
                    case "msg":
                        message = item.Value.ToString();
                        break;

                    default:
                        if (item.Value is Exception e)
                        {
                            var e1 = SerializeException(e, _parameters);
                            StringBuilder sb = new StringBuilder(5 * 1024);
                            e1.Serialize(sb);
                            _parameters.Add(new KeyValuePair<string, object>(item.Key, GetBase64Text(sb)));
                        }
                        else
                            _parameters.Add(new KeyValuePair<string, object>(item.Key, item.Value));

                        break;

                }

            }

            return _parameters;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LogInternal(Level logLevel, string message, Exception ex, List<KeyValuePair<string, object>> dicParameters)
        {

            if (logLevel != Level.Off)
            {

                log4net.Core.LoggingEvent logEntry = CreateLogEntry(logLevel, message, ex, dicParameters);

                try
                {
                    _logger.Log(logEntry);
                    if (Events != null)
                        PushEvent(logEntry, false);
                }
                catch (Exception ex1)
                {
                    if (Events != null)
                        PushEvent(logEntry, true);
                    Console.WriteLine("Log fail. " + ex1.Message);
                }

            }

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LogInternal(Level logLevel, string message, List<KeyValuePair<string, object>> dicParameters)
        {

            if (logLevel != Level.Off)
            {
                log4net.Core.LoggingEvent logEntry = CreateLogEntry(logLevel, message, null, dicParameters);
                Push(logEntry);
            }

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Push(LoggingEvent logEntry)
        {
            try
            {
                _logger.Log(logEntry);
                if (Events != null)
                    PushEvent(logEntry, false);
            }
            catch (Exception ex1)
            {
                if (Events != null)
                    PushEvent(logEntry, false);
                Console.WriteLine("Log fail. " + ex1.Message);

            }
        }

        private void PushEvent(LoggingEvent logEntry, bool failed)
        {

            Events(this, new LogEventArg()
            {

                FailedToPushLog = failed,

                Message = logEntry.RenderedMessage,
                Level = logEntry.Level.Name,
                UserName = logEntry.UserName,
                Domain = logEntry.Domain,
                TimeStampUtc = logEntry.TimeStampUtc,
                ThreadName = logEntry.ThreadName,
                LoggerName = logEntry.LoggerName,
                //LocationInformation = logEntry.LocationInformation,
                Identity = logEntry.Identity,
                Properties = GetProperties(logEntry.Properties),

            });

        }

        private IEnumerable<KeyValuePair<string, object>> GetProperties(log4net.Util.PropertiesDictionary properties)
        {

            List<KeyValuePair<string, object>> result = new List<KeyValuePair<string, object>>();

            foreach (System.Collections.DictionaryEntry item in properties)
                result.Add(new KeyValuePair<string, object>(item.Key.ToString(), item.Value));

            return result;

        }

        public static event EventHandler<LogEventArg> Events;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private log4net.Core.LoggingEvent CreateLogEntry(log4net.Core.Level level, string message, Exception ex, List<KeyValuePair<string, object>> customInfos)
        {

            customInfos.Add(new KeyValuePair<string, object>("session", _sessionId));

            if (ex != null)
            {
                var e1 = SerializeException(ex, customInfos);
                StringBuilder sb = new StringBuilder(5 * 1024);
                e1.Serialize(sb);
                customInfos.Add(new KeyValuePair<string, object>("Exception", GetBase64Text(sb)));
            }

            string m = !string.IsNullOrEmpty(message)
                ? message
                : ex != null && ex.Message != null
                    ? ex.Message
                    : string.Empty;

            LoggingEvent result = Generate(level, m);

            foreach (var item in customInfos)
                if (!string.IsNullOrEmpty(item.Key))
                    result.Properties[item.Key] = item.Value;

            return result;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetBase64Text(StringBuilder sb)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(sb.ToString()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private LoggingEvent Generate(log4net.Core.Level level, string m)
        {

            StackFrame stackFrame = null;
            System.Reflection.MethodBase method = null;
            var stackFrames = new StackTrace().GetFrames();
            for (int indexFrame = 0; indexFrame < stackFrames.Length; ++indexFrame)
            {
                stackFrame = stackFrames[indexFrame];
                method = stackFrame.GetMethod();
                if (method.DeclaringType != typeof(Log4NetTraceListener) && method.Name != "TraceInternals")
                    break;
            }

            var result = new log4net.Core.LoggingEvent(method.ReflectedType, _repository, new LoggingEventData()
            {
                Level = level,
                Message = m,
                LoggerName = base.Name,
                LocationInfo = new LocationInfo(GetMethodName(method),
                                                method.ToString(),
                                                stackFrame.GetFileName(),
                                                stackFrame.GetFileLineNumber().ToString())
            }, FixFlags.All);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string GetMethodName(System.Reflection.MethodBase method)
        {
            var type = method.ReflectedType;
            if (type != null)
            {
                return type.Name;
            }
            else
            {
                return method.ToString();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ExceptionDescriptor SerializeException(Exception ex, List<KeyValuePair<string, object>> dicParameters)
        {

            ExceptionDescriptor exceptionDescriptor = new ExceptionDescriptor()
            {
                Message = ex.Message,
            };

            var stack = new StackTrace(ex);
            StringBuilder sb1 = new StringBuilder();

            Stack<StringBuilder> _st = new Stack<StringBuilder>();
            foreach (StackFrame frame in stack.GetFrames())
            {
                var method = frame.GetMethod();
                AssemblyLogger.Instance.GetAssemblies(method.DeclaringType.Assembly, _st);
                exceptionDescriptor.Stack.Add(new CodeDescriptor(frame.GetILOffset(), method));
            }

            PushAssembliesinLog(_st);

            if (ex.InnerException != null)
                exceptionDescriptor.Inner = SerializeException(ex.InnerException, dicParameters);
            
            return exceptionDescriptor;

        }

        private void PushAssembliesinLog(Stack<StringBuilder> _st)
        {
            while (_st.Count > 0)
            {

                var sb = _st.Pop();

                string name = ExtractName(sb);

                var result = new LoggingEvent
                (
                    GetType(), _repository,
                    new LoggingEventData()
                    {
                        Level = Level.Fatal,
                        Message = "assembly_content",
                        LoggerName = base.Name,
                    },
                    FixFlags.All
                );

                result.Properties["session"] = _sessionId;
                result.Properties[name] = sb.ToString();

                this.Push(result);

            }
        }

        private static string ExtractName(StringBuilder sb)
        {
            StringBuilder sb2 = new StringBuilder(100);
            for (int index = 0; index < sb.Length; index++)
            {
                var c = sb[index];
                if (c == ';')
                {
                    sb.Remove(0, index + 1);
                    break;
                }
                else
                    sb2.Append(c);
            }

            return sb2.ToString();

        }

        private readonly ILogger _logger;
        private readonly ILoggerRepository _repository;
        private readonly static string _sessionId;

    }

}



//System.Text.StringBuilder sb = new System.Text.StringBuilder();
//var reader = ExceptionObjectSource.Extract(ex);
//while (reader.Count > 0)
//{
//    MyException i = reader.Dequeue();
//    sb.AppendLine(i.Message + "<BR />");
//    foreach (MyFrame item in i.stackTrace)
//        sb.AppendLine(item.ReflectionMethod.Code);
//}
//dicParameters.Add(new KeyValuePair<string, object>("code", sb.ToString()));
