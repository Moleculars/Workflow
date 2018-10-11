namespace Bb.Sdk.Loggings.Exceptions.IlParser
{
    using Bb.Sdk.Exceptions;
    using System;

    /// <summary>
    /// IILStringCollector
    /// </summary>
    public interface IILStringCollector
    {
        /// <summary>
        /// Processes the specified il instruction.
        /// </summary>
        /// <param name="ilInstruction">The il instruction.</param>
        /// <param name="operandString">The operand string.</param>
        void Process(ILInstruction ilInstruction, string operandString);

        void Initialize(MethodBodyInfo mbi, int offset);

    }
}
