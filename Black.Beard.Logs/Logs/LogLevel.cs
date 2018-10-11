using log4net.Core;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Bb.Logs
{
    internal static class LogLevel
    {

        static LogLevel()
        {
            _level = new Dictionary<string, Level>();

        }

        internal static void AddLevel(int value, string name, string displayName)
        {
            _level.Add(name, new Level(value, name, displayName));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Level ConvertLevel(this string category)
        {

            string cat = category.ToLower();

            switch (cat)
            {

                case "off":
                    return Level.Off;           // 2 147 483 647

                case "log4net_debug":
                    return Level.Log4Net_Debug; // 120 000

                case "emergency":
                    return Level.Emergency;     // 120 000

                case "fatal":
                    return Level.Fatal;         // 110 000

                case "alert":
                    return Level.Alert;         // 100 000

                case "critical":
                    return Level.Critical;      // 90 000

                case "severe":
                    return Level.Severe;        // 80 000

                case "error":
                    return Level.Error;         // 70 000

                case "warn":
                    return Level.Warn;          // 60 000

                case "notice":
                    return Level.Notice;        // 50 000

                case "info":
                    return Level.Info;          // 40 000

                case "debug":
                    return Level.Debug;         // 30 000

                case "fine":
                    return Level.Fine;          // 30 000

                case "finer":
                    return Level.Finer;         // 20 000

                case "trace":
                    return Level.Trace;         // 20 000

                case "finest":
                    return Level.Finest;        // 10 000

                case "verbose":
                    return Level.Verbose;       // 10 000

                case "all":
                    return Level.All;           // -2 147 483 648

                default:
                    if (!_level.TryGetValue(cat, out Level level))
                        lock(_lock)
                            if (!_level.TryGetValue(cat, out level))
                                _level.Add(cat, (level = new Level(Level.Verbose.Value - 1, cat)));

                    return level;
                    
            }

        }

        private static Dictionary<string, Level> _level;
        private static readonly object _lock = new object();

    }

}
