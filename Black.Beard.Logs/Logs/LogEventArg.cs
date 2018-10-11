using System;
using System.Collections.Generic;

namespace Bb.Logs
{
    public class LogEventArg : System.EventArgs
    {

        public string Level { get; internal set; }
        public IEnumerable<KeyValuePair<string, object>> Properties { get; internal set; }
        public string Identity { get; internal set; }
        public string UserName { get; internal set; }
        public string Domain { get; internal set; }
        public DateTime TimeStampUtc { get; internal set; }
        public string LoggerName { get; internal set; }
        public string ThreadName { get; internal set; }
        public string Message { get; internal set; }
        public bool FailedToPushLog { get; internal set; }
    }

}
