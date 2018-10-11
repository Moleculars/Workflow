using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Bb.Core.Helpers;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.BusinessRule.Parser
{

    public class BusinessRuleConfigParser
    {

        private BusinessRuleConfigParser(TextWriter output, TextWriter outputError)
        {

            this.Output = output ?? Console.Out;
            this.OutputError = outputError ?? Console.Error;

        }

        public static BusinessRuleConfigParser ParseString(StringBuilder source, string sourceFile = "", TextWriter output = null, TextWriter outputError = null)
        {
            ICharStream stream = CharStreams.fromstring(source.ToString());

            var parser = new BusinessRuleConfigParser(output, outputError)
            {
                File = sourceFile ?? string.Empty,
                Content = source,
                Crc = Crc32.Calculate(source),
            };
            parser.ParseCharStream(stream);
            return parser;

        }

        public static BusinessRuleConfigParser ParsePath(string source, TextWriter output = null, TextWriter outputError = null)
        {

            var payload = LoadContent(source);
            ICharStream stream = CharStreams.fromstring(payload.ToString());

            var parser = new BusinessRuleConfigParser(output, outputError)
            {
                File = source,
                Content = payload,
                Crc = Crc32.Calculate(payload),
            };
            parser.ParseCharStream(stream);
            return parser;

        }

        /// <summary>
        /// Loads the content of the file.
        /// </summary>
        /// <param name="rootSource">The root source.</param>
        /// <returns></returns>
        public static StringBuilder LoadContent(string rootSource)
        {
            StringBuilder result = new StringBuilder(BusinessRuleContentHelper.LoadContentFromFile(rootSource));
            return result;
        }

        public static bool Trace { get; set; }

        public BusinessRuleParser.ScriptContext Tree { get { return this._context; } }

        public string File { get; set; }

        public StringBuilder Content { get; private set; }

        public TextWriter Output { get; private set; }

        public TextWriter OutputError { get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Visit<Result>(IParseTreeVisitor<Result> visitor)
        {

            if (visitor is IFile f)
                f.Filename = this.File;

            if (System.Diagnostics.Debugger.IsAttached)
                System.Diagnostics.Trace.WriteLine(this.File);

            var context = this._context;
            return visitor.Visit(context);

        }

        public bool InError { get => this._parser.ErrorListeners.Count > 0; }
        public uint Crc { get; private set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ParseCharStream(ICharStream stream)
        {

            var lexer = new BusinessRuleLexer(stream, this.Output, this.OutputError);
            var token = new CommonTokenStream(lexer);
            this._parser = new BusinessRuleParser(token)
            {
                BuildParseTree = true,
                //Trace = ScriptParser.Trace, // Ca plante sur un null, pourquoi ?
            };

            _context = _parser.script();

        }

        private BusinessRuleParser _parser;
        private BusinessRuleParser.ScriptContext _context;

    }


    public interface IFile
    {

        string Filename { get; set; }

    }

}
