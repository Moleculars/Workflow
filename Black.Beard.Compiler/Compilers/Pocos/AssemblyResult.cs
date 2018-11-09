using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Bb.Compilers.Pocos
{
    public class AssemblyResult
    {

        public AssemblyResult()
        {
            Disgnostics = new List<DiagnosticResult>();
        }

        public string AssemblyName { get; internal set; }

        public string CodeFile { get; internal set; }

        public string AssemblyFile { get; internal set; }

        public string AssemblyFilePdb { get; internal set; }

        public List<DiagnosticResult> Disgnostics { get; internal set; }
        public bool Success { get; internal set; }
        public Exception Exception { get; internal set; }

        public Assembly Load()
        {
            Trace.WriteLine($"Loading assembly {AssemblyFile}");
            return Assembly.LoadFile(AssemblyFile);
        }

    }

}
