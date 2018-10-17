using Bb.Logs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Bb.Workflow.Service
{

    /// <summary>
    /// Class main 
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Subprogram main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            using (var listener = Log4NetTraceListener.Initialize("MyLog"))
            {

                CreateWebHostBuilder(args)
                    .Build()
                    .Run();

            }

        }

        /// <summary>
        /// Create a webhost
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}

// Code Editor 

// https://ace.c9.io/
// https://codemirror.net/

// http://markitup.jaysalvat.com/home/
// https://www.cdolivet.com/editarea/
// http://codepress.sourceforge.net/