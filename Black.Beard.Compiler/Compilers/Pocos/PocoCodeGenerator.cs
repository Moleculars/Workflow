using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bb.Compilers.Pocos
{

    internal class PocoCodeGenerator
    {


        internal PocoCodeGenerator(HashSet<Assembly> assemblies)
        {

            assemblies.Add(typeof(System.Object).Assembly);
            assemblies.Add(typeof(System.ComponentModel.DescriptionAttribute).Assembly);

            var ass = new string[] { "netstandard", "mscorlib", "System.Runtime" };

            foreach (var item in ass)
            {
                var a = item.ResolveAssemblyByName();
                if (a != null)
                    assemblies.Add(a);
            }

            _defaultReferences = new List<MetadataReference>();
            foreach (Assembly assembly in assemblies)
            {
                var newReference = AssemblyMetadata.CreateFromFile(assembly.Location).GetReference();
                _defaultReferences.Add(newReference);
            }

        }

        public AssemblyResult Generate(PocoModelRepository repository, string outputPah)
        {

            // Generate code
            string crc = repository.Crc().ToString();
            string namespaceName = $"{repository.AssemblyName}_{crc}";

            AssemblyResult result = GetAssemblyResult(outputPah, namespaceName);

            CodeNamespace ns = new CodeNamespace(namespaceName);
            GenerateModels(repository, crc, ns);
            GenerateUsing(repository, ns);

            var code = GenerateCode(ns);

            ResetFilesIfExists(result);

            File.AppendAllText(result.CodeFile, code.ToString());

            var parsedSyntaxTree = Parse(code, result);

            CSharpCompilationOptions DefaultCompilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                    .WithOverflowChecks(true)

                    .WithOptimizationLevel(System.Diagnostics.Debugger.IsAttached
                        ? Microsoft.CodeAnalysis.OptimizationLevel.Debug
                        : Microsoft.CodeAnalysis.OptimizationLevel.Release)

                    .WithPlatform(Platform.AnyCpu)
                    .WithModuleName($"{namespaceName}.dll")
                    .WithUsings(repository.Usings);

            var compilation = CSharpCompilation.Create
                (
                    result.AssemblyName,
                    new Microsoft.CodeAnalysis.SyntaxTree[] { parsedSyntaxTree },
                    _defaultReferences,
                    DefaultCompilationOptions
                );

            try
            {

                // emit the compilation result to a byte array corresponding to {AssemblyName}.netmodule byte code
                //byte[] compilationAResult = compilation.EmitToArray(DiagnosticSeverity.Error, out CompilerException exception);
                //Assembly newAssembly = Assembly.Load(compilationAResult);

                using (var peStream = File.Create(result.AssemblyFile))
                using (var pdbStream = File.Create(result.AssemblyFilePdb))
                {
                    Microsoft.CodeAnalysis.Emit.EmitResult resultEmit = compilation.Emit(peStream, pdbStream);
                    var diags = resultEmit.Diagnostics.ToList().Select(c => c.ToString()).ToArray();
                    Trace.WriteLine(
                        new
                        {
                            Message = $"Compilation of {result.AssemblyName} return : " + (resultEmit.Success ? " Success!!" : " Failed"),
                            Diagnostics = string.Join(", ", diags),
                        });

                    // Map diagnostic for not reference roslyn outsite this assembly
                    foreach (Diagnostic diagnostic in resultEmit.Diagnostics)
                        result.Disgnostics.Add(diagnostic.Map());

                    result.Success = resultEmit.Success;

                    if (!resultEmit.Success && System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();

                }

            }
            catch (Exception ex)
            {

                result.Excepton = ex;

                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();

                Trace.WriteLine(new { Message = $"Compilation of {result.AssemblyName} return : ", Exception = ex });

            }

            return result;

        }

        private static AssemblyResult GetAssemblyResult(string outputPah, string namespaceName)
        {

            if (!Directory.Exists(outputPah))
                Directory.CreateDirectory(outputPah);

            return new AssemblyResult()
            {
                AssemblyName = namespaceName,
                CodeFile = Path.Combine(outputPah, $"{namespaceName}.cs"),
                AssemblyFile = Path.Combine(outputPah, $"{namespaceName}.dll"),
                AssemblyFilePdb = Path.Combine(outputPah, $"{namespaceName}.pdb"),
            };

        }

        private static void ResetFilesIfExists(AssemblyResult result)
        {
            if (File.Exists(result.CodeFile))
                File.Delete(result.CodeFile);

            if (File.Exists(result.AssemblyFile))
                File.Delete(result.AssemblyFile);

            if (File.Exists(result.AssemblyFilePdb))
                File.Delete(result.AssemblyFilePdb);
        }

        public static Microsoft.CodeAnalysis.SyntaxTree Parse(StringBuilder text, AssemblyResult files)
        {
            CSharpParseOptions options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp6);
            var stringText = Microsoft.CodeAnalysis.Text.SourceText.From(text.ToString(), Encoding.UTF8);
            return SyntaxFactory.ParseSyntaxTree(stringText, options, files.CodeFile);
        }

        private static void GenerateUsing(PocoModelRepository repository, CodeNamespace ns)
        {
            foreach (string item in repository.Usings)
                ns.Imports.Add(new CodeNamespaceImport(item));
        }

        private static void GenerateModels(PocoModelRepository repository, string crc, CodeNamespace ns)
        {
            foreach (var poco in repository.Pocos)
            {

                CodeTypeDeclaration type = new CodeTypeDeclaration($"{poco.Name}_{crc}")
                {
                    IsClass = true,
                };

                if (!string.IsNullOrEmpty(poco.Description))
                {
                    type.Comments.Add(new CodeCommentStatement("<summary>", true));
                    type.Comments.Add(new CodeCommentStatement(poco.Description, true));
                    type.Comments.Add(new CodeCommentStatement("</summary>", true));
                    new System.ComponentModel.DescriptionAttribute(poco.Description);

                    repository.Usings.Add("System.ComponentModel");

                    AppendAttribute(
                    type.CustomAttributes,
                    Attribute(nameof(System.ComponentModel.DescriptionAttribute),
                        new PocoModelAttributeArgument()
                        {
                            Value = poco.Description,
                            IsString = true
                        })
                    );
                }

                AppendAttributes(poco.Attributes, type.CustomAttributes);

                if (!string.IsNullOrEmpty(poco.BaseName))
                {
                    if (repository.Pocos.Any(c => c.Name == poco.BaseName))
                        type.BaseTypes.Add($"{poco.BaseName}_{crc}");
                    else
                        type.BaseTypes.Add(poco.BaseName);
                }

                foreach (var _interface in poco.Interfaces)
                    type.BaseTypes.Add(_interface);

                GenerateProperties(repository, crc, poco, type);

                ns.Types.Add(type);

            }
        }

        private static void AppendAttributes(PocoModelAttributes attributes, CodeAttributeDeclarationCollection target)
        {

            foreach (PocoModelAttribute attribute in attributes)
                AppendAttribute(target, attribute);

        }

        private static void AppendAttribute(CodeAttributeDeclarationCollection target, PocoModelAttribute attribute)
        {
            var _attribute = new CodeAttributeDeclaration(attribute.Name);
            foreach (PocoModelAttributeArgument arg in attribute.Arguments)
            {

                var v = arg.IsString
                        ? new CodePrimitiveExpression(arg.Value)
                        : (CodeExpression)new CodeSnippetExpression(arg.Value);

                _attribute.Arguments.Add(new CodeAttributeArgument()
                {
                    Name = arg.Name,
                    Value = v
                });
            }

            target.Add(_attribute);
        }

        private static StringBuilder GenerateCode(CodeNamespace ns)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            unit.Namespaces.Add(ns);

            CSharpCodeProvider provider = new CSharpCodeProvider();

            MemoryStream mem = new MemoryStream();

            using (StreamWriter sw = new StreamWriter(mem, System.Text.Encoding.UTF8))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");

                // Generate source code using the code provider.
                provider.GenerateCodeFromCompileUnit(unit, tw, new CodeGeneratorOptions());

                // Close the output file.
                tw.Close();
            }

            var sb = new StringBuilder(System.Text.Encoding.UTF8.GetString(mem.ToArray()));

            return sb;

        }

        private static void GenerateProperties(PocoModelRepository repository, string crc, PocoModel poco, CodeTypeDeclaration type)
        {

            foreach (var property in poco.Properties)
                GenerateProperty(repository, crc, poco, type, property);

        }

        private static PocoModelAttribute Attribute(string name, params PocoModelAttributeArgument[] args)
        {

            if (name.EndsWith("Attribute"))
                name = name.Substring(0, name.Length - 9);

            return new PocoModelAttribute()
            {
                Name = name,
                Arguments = new PocoModelAttributeArguments(args)
            };

        }

        private static void GenerateProperty(PocoModelRepository repository, string crc, PocoModel poco, CodeTypeDeclaration type, PocoProperty property)
        {

            CodeTypeReference tt = ResolveType(repository, crc, poco, property);

            var _property = new CodeMemberProperty()
            {
                Attributes = MemberAttributes.Public,
                Name = property.Name,
                Type = tt,
            };

            if (!string.IsNullOrEmpty(property.Description))
            {
                _property.Comments.Add(new CodeCommentStatement(property.Description, true));
                new System.ComponentModel.DescriptionAttribute(property.Description);

                repository.Usings.Add("System.ComponentModel");
                AppendAttribute(
                    _property.CustomAttributes,
                    Attribute(nameof(System.ComponentModel.DescriptionAttribute),
                    new PocoModelAttributeArgument()
                    {
                        Value = property.Description,
                        IsString = true
                    })
                );
            }

            AppendAttributes(property.Attributes, _property.CustomAttributes);

            _property.HasGet = true;
            string fiedName = "_" + property.Name[0].ToString().ToLower() + property.Name.Substring(1);
            var field = new CodeFieldReferenceExpression() { FieldName = fiedName, TargetObject = new CodeThisReferenceExpression() };
            _property.GetStatements.Add(new CodeMethodReturnStatement(field));

            _property.HasSet = true;
            _property.SetStatements.Add(new CodeAssignStatement(field, new CodeFieldReferenceExpression() { FieldName = "value" }));

            type.Members.Add(_property);
            type.Members.Add(new CodeMemberField(tt, fiedName));

        }

        private static CodeTypeReference ResolveType(PocoModelRepository repository, string crc, PocoModel poco, PocoProperty property)
        {
            string propertyType = property.Type;
            PocoModel reference = repository.Get(propertyType);
            if (reference == null)
            {
                var typeRef = Type.GetType(propertyType);
                if (typeRef == null)
                {
                    //     throw new Exception($"{propertyType} can't be resolved in {poco.Name}.{property.Name}");
                }
            }
            else
                propertyType = $"{propertyType}_{crc}";

            var tt = property.IsArray
                    ? new CodeTypeReference(new CodeTypeReference(propertyType), 1)
                    : new CodeTypeReference(propertyType);

            return tt;

        }

        private static readonly string runtimePath = Path.Combine(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(), "{0}.dll");
        private readonly List<MetadataReference> _defaultReferences;

    }

}
