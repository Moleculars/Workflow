namespace Bb.Sdk.Loggings.Exceptions.IlParser
{
    using System;
    using System.Reflection.Emit;

    /// <summary>
    /// InlineRInstruction
    /// </summary>
    public class InlineRInstruction : ILInstruction
    {
        private double m_value;

        internal InlineRInstruction(int offset, OpCode opCode, double value) : base(offset, opCode)
        {
            this.m_value = value;
        }

        /// <summary>
        /// Accepts the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public override void Accept(ILInstructionVisitor visitor)
        {
            visitor.VisitInlineRInstruction(this);
        }

        /// <summary>
        /// Gets the double.
        /// </summary>
        /// <value>
        /// The double.
        /// </value>
        public double Double
        {
            get
            {
                return this.m_value;
            }
        }
    }
}
