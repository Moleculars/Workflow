//namespace Bb.Sdk.Loggings.Exceptions.IlParser
//{
//    using Exceptions;
//    using System;
//    using System.IO;

//    /// <summary>
//    /// ReadableILStringToTextWriter
//    /// </summary>
//    public class ReadableILStringToTextWriter : IILStringCollector
//    {
//        /// <summary>
//        /// The writer
//        /// </summary>
//        protected TextWriter writer;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="ReadableILStringToTextWriter"/> class.
//        /// </summary>
//        /// <param name="writer">The writer.</param>
//        public ReadableILStringToTextWriter(TextWriter writer)
//        {
//            this.writer = writer;
//        }

//        /// <summary>
//        /// Processes the specified il instruction.
//        /// </summary>
//        /// <param name="ilInstruction">The il instruction.</param>
//        /// <param name="operandString">The operand string.</param>
//        public virtual void Process(ILInstruction ilInstruction, string operandString)
//        {
//            this.writer.WriteLine(Constants.ILMask, ilInstruction.Offset, ilInstruction.OpCode.Name, operandString);
//        }
//    }
//}
