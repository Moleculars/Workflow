﻿using Bb.Compilers.Exceptions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Bb.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Compilers
{


    public class Compiler
    {

        public Compiler(string assemblyOrModuleName = null)
        {

            _objects = new List<StringBuilder>();
            _references = new List<MetadataReference>();
            _assemblyOrModuleName = assemblyOrModuleName;

            MetadataReference mscoreLibReference = AssemblyMetadata.CreateFromFile(typeof(string).Assembly.Location).GetReference();
            _references.Add(mscoreLibReference);

        }

        /// <summary>
        /// Append a reference to specified assembly
        /// </summary>
        /// <param name="assembly"></param>
        public void AppendReference(System.Reflection.Assembly assembly)
        {

            MetadataReference mscoreLibReference = AssemblyMetadata.CreateFromFile(assembly.Location).GetReference();

        }

        /// <summary>
        /// Append an object to module
        /// </summary>
        /// <param name="sourceSb"></param>
        public void AppendSource(StringBuilder sourceSb)
        {
            _objects.Add(sourceSb);
        }

        public MetadataReference Generate()
        {

            byte[] compilationAResult = GetBytes();

            // create a reference to AssemblyName.netmodule
            MetadataReference reference = ModuleMetadata.CreateFromImage(compilationAResult)
                    .GetReference(display: $"{AssemblyName}.netmodule");

            return reference;

        }

        private string AssemblyName
        {
            get
            {

                if (string.IsNullOrEmpty(_assemblyOrModuleName))
                {

                    StringBuilder sb = new StringBuilder(2000);

                    foreach (StringBuilder sb2 in this._objects)
                        sb.Append(sb2.ToString()
                            .Replace(" ","")
                            .Replace("\t", "")
                            .Replace("\r", "")
                            .Replace("\n", ""));

                    this._assemblyOrModuleName = $"AutoGeneratedAssembly_{Crc32.Calculate(sb)}";

                }

                return _assemblyOrModuleName;

            }
        }

        /// <summary>
        /// Generate the new Assembly
        /// </summary>
        /// <returns></returns>
        public Assembly GenerateAssemby()
        {

            byte[] compilationResult = GetBytes();

            Assembly newAssembly = Assembly.Load(compilationResult);
            return newAssembly;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private byte[] GetBytes()
        {
            var compilation = CreateCompilation(compilerOptions: new CSharpCompilationOptions(OutputKind.NetModule));

            // emit the compilation result to a byte array corresponding to {AssemblyName}.netmodule byte code
            byte[] compilationAResult = compilation.EmitToArray(DiagnosticSeverity.Error, out CompilerException exception);
            return compilationAResult;
        }

        private CSharpCompilation CreateCompilation(CSharpCompilationOptions compilerOptions = null)
        {

            // create the syntax trees
            var sources = _objects.Select(code => SyntaxFactory.ParseSyntaxTree(code.ToString(), null, "")).ToArray();

            // create and return the compilation
            CSharpCompilation compilation = CSharpCompilation.Create
            (
                this.AssemblyName,
                sources,
                options: compilerOptions,
                references: _references
            );

            return compilation;

        }

        private string _assemblyOrModuleName;
        private List<StringBuilder> _objects;
        private List<MetadataReference> _references;

    }

}
