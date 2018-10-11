using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pssa.Sdk.Loggings.Exceptions.Asts
{

    public static class OpCodes
    {

        internal static readonly OpCode[] OneByteOpCode = new OpCode[0xe0 + 1];
        internal static readonly OpCode[] TwoBytesOpCode = new OpCode[0x1e + 1];

        public static readonly OpCode Nop = new OpCode(
            0xff << 0 | 0x00 << 8 | (byte)System.Reflection.Emit.OpCodes.Nop.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Break = new OpCode(
            0xff << 0 | 0x01 << 8 | (byte)System.Reflection.Emit.OpCodes.Break.ToByte() << 16 | (byte)FlowControl.Break << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldarg_0 = new OpCode(
            0xff << 0 | 0x02 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarg_0.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldarg_1 = new OpCode(
            0xff << 0 | 0x03 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarg_1.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldarg_2 = new OpCode(
            0xff << 0 | 0x04 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarg_2.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldarg_3 = new OpCode(
            0xff << 0 | 0x05 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarg_3.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldloc_0 = new OpCode(
            0xff << 0 | 0x06 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloc_0.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldloc_1 = new OpCode(
            0xff << 0 | 0x07 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloc_1.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldloc_2 = new OpCode(
            0xff << 0 | 0x08 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloc_2.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldloc_3 = new OpCode(
            0xff << 0 | 0x09 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloc_3.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Stloc_0 = new OpCode(
            0xff << 0 | 0x0a << 8 | (byte)System.Reflection.Emit.OpCodes.Stloc_0.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stloc_1 = new OpCode(
            0xff << 0 | 0x0b << 8 | (byte)System.Reflection.Emit.OpCodes.Stloc_1.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stloc_2 = new OpCode(
            0xff << 0 | 0x0c << 8 | (byte)System.Reflection.Emit.OpCodes.Stloc_2.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stloc_3 = new OpCode(
            0xff << 0 | 0x0d << 8 | (byte)System.Reflection.Emit.OpCodes.Stloc_3.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldarg_S = new OpCode(
            0xff << 0 | 0x0e << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarg_S.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineArg << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldarga_S = new OpCode(
            0xff << 0 | 0x0f << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarga_S.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineArg << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Starg_S = new OpCode(
            0xff << 0 | 0x10 << 8 | (byte)System.Reflection.Emit.OpCodes.Starg_S.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineArg << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldloc_S = new OpCode(
            0xff << 0 | 0x11 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloc_S.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineVar << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldloca_S = new OpCode(
            0xff << 0 | 0x12 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloca_S.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineVar << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Stloc_S = new OpCode(
            0xff << 0 | 0x13 << 8 | (byte)System.Reflection.Emit.OpCodes.Stloc_S.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineVar << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldnull = new OpCode(
            0xff << 0 | 0x14 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldnull.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Ldc_I4_M1 = new OpCode(
            0xff << 0 | 0x15 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_M1.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_0 = new OpCode(
            0xff << 0 | 0x16 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_0.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_1 = new OpCode(
            0xff << 0 | 0x17 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_1.ToByte() << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_2 = new OpCode(
            0xff << 0 | 0x18 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_3 = new OpCode(
            0xff << 0 | 0x19 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_3 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_4 = new OpCode(
            0xff << 0 | 0x1a << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_5 = new OpCode(
            0xff << 0 | 0x1b << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_5 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_6 = new OpCode(
            0xff << 0 | 0x1c << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_6 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_7 = new OpCode(
            0xff << 0 | 0x1d << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_7 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_8 = new OpCode(
            0xff << 0 | 0x1e << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4_S = new OpCode(
            0xff << 0 | 0x1f << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4_S << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineI << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I4 = new OpCode(
            0xff << 0 | 0x20 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineI << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldc_I8 = new OpCode(
            0xff << 0 | 0x21 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_I8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineI8 << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Ldc_R4 = new OpCode(
            0xff << 0 | 0x22 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_R4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.ShortInlineR << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushr4 << 24);

        public static readonly OpCode Ldc_R8 = new OpCode(
            0xff << 0 | 0x23 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldc_R8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineR << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushr8 << 24);

        public static readonly OpCode Dup = new OpCode(
            0xff << 0 | 0x25 << 8 | (byte)System.Reflection.Emit.OpCodes.Dup << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push1_push1 << 24);

        public static readonly OpCode Pop = new OpCode(
            0xff << 0 | 0x26 << 8 | (byte)System.Reflection.Emit.OpCodes.Pop << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Jmp = new OpCode(
            0xff << 0 | 0x27 << 8 | (byte)System.Reflection.Emit.OpCodes.Jmp << 16 | (byte)FlowControl.Call << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineMethod << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Call = new OpCode(
            0xff << 0 | 0x28 << 8 | (byte)System.Reflection.Emit.OpCodes.Call << 16 | (byte)FlowControl.Call << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineMethod << 8 | (byte)StackBehaviour.Varpop << 16 | (byte)StackBehaviour.Varpush << 24);

        public static readonly OpCode Calli = new OpCode(
            0xff << 0 | 0x29 << 8 | (byte)System.Reflection.Emit.OpCodes.Calli << 16 | (byte)FlowControl.Call << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineSig << 8 | (byte)StackBehaviour.Varpop << 16 | (byte)StackBehaviour.Varpush << 24);

        public static readonly OpCode Ret = new OpCode(
            0xff << 0 | 0x2a << 8 | (byte)System.Reflection.Emit.OpCodes.Ret << 16 | (byte)FlowControl.Return << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Varpop << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Br_S = new OpCode(
            0xff << 0 | 0x2b << 8 | (byte)System.Reflection.Emit.OpCodes.Br_S << 16 | (byte)FlowControl.Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Brfalse_S = new OpCode(
            0xff << 0 | 0x2c << 8 | (byte)System.Reflection.Emit.OpCodes.Brfalse_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Brtrue_S = new OpCode(
            0xff << 0 | 0x2d << 8 | (byte)System.Reflection.Emit.OpCodes.Brtrue_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Beq_S = new OpCode(
            0xff << 0 | 0x2e << 8 | (byte)System.Reflection.Emit.OpCodes.Beq_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bge_S = new OpCode(
            0xff << 0 | 0x2f << 8 | (byte)System.Reflection.Emit.OpCodes.Bge_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bgt_S = new OpCode(
            0xff << 0 | 0x30 << 8 | (byte)System.Reflection.Emit.OpCodes.Bgt_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ble_S = new OpCode(
            0xff << 0 | 0x31 << 8 | (byte)System.Reflection.Emit.OpCodes.Ble_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Blt_S = new OpCode(
            0xff << 0 | 0x32 << 8 | (byte)System.Reflection.Emit.OpCodes.Blt_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bne_Un_S = new OpCode(
            0xff << 0 | 0x33 << 8 | (byte)System.Reflection.Emit.OpCodes.Bne_Un_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bge_Un_S = new OpCode(
            0xff << 0 | 0x34 << 8 | (byte)System.Reflection.Emit.OpCodes.Bge_Un_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bgt_Un_S = new OpCode(
            0xff << 0 | 0x35 << 8 | (byte)System.Reflection.Emit.OpCodes.Bgt_Un_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ble_Un_S = new OpCode(
            0xff << 0 | 0x36 << 8 | (byte)System.Reflection.Emit.OpCodes.Ble_Un_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Blt_Un_S = new OpCode(
            0xff << 0 | 0x37 << 8 | (byte)System.Reflection.Emit.OpCodes.Blt_Un_S << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Br = new OpCode(
            0xff << 0 | 0x38 << 8 | (byte)System.Reflection.Emit.OpCodes.Br << 16 | (byte)FlowControl.Branch << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Brfalse = new OpCode(
            0xff << 0 | 0x39 << 8 | (byte)System.Reflection.Emit.OpCodes.Brfalse << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Brtrue = new OpCode(
            0xff << 0 | 0x3a << 8 | (byte)System.Reflection.Emit.OpCodes.Brtrue << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Beq = new OpCode(
            0xff << 0 | 0x3b << 8 | (byte)System.Reflection.Emit.OpCodes.Beq << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bge = new OpCode(
            0xff << 0 | 0x3c << 8 | (byte)System.Reflection.Emit.OpCodes.Bge << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bgt = new OpCode(
            0xff << 0 | 0x3d << 8 | (byte)System.Reflection.Emit.OpCodes.Bgt << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ble = new OpCode(
            0xff << 0 | 0x3e << 8 | (byte)System.Reflection.Emit.OpCodes.Ble << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Blt = new OpCode(
            0xff << 0 | 0x3f << 8 | (byte)System.Reflection.Emit.OpCodes.Blt << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bne_Un = new OpCode(
            0xff << 0 | 0x40 << 8 | (byte)System.Reflection.Emit.OpCodes.Bne_Un << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bge_Un = new OpCode(
            0xff << 0 | 0x41 << 8 | (byte)System.Reflection.Emit.OpCodes.Bge_Un << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Bgt_Un = new OpCode(
            0xff << 0 | 0x42 << 8 | (byte)System.Reflection.Emit.OpCodes.Bgt_Un << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ble_Un = new OpCode(
            0xff << 0 | 0x43 << 8 | (byte)System.Reflection.Emit.OpCodes.Ble_Un << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Blt_Un = new OpCode(
            0xff << 0 | 0x44 << 8 | (byte)System.Reflection.Emit.OpCodes.Blt_Un << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Switch = new OpCode(
            0xff << 0 | 0x45 << 8 | (byte)System.Reflection.Emit.OpCodes.Switch << 16 | (byte)FlowControl.Cond_Branch << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineSwitch << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldind_I1 = new OpCode(
            0xff << 0 | 0x46 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_I1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldind_U1 = new OpCode(
            0xff << 0 | 0x47 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_U1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldind_I2 = new OpCode(
            0xff << 0 | 0x48 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_I2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldind_U2 = new OpCode(
            0xff << 0 | 0x49 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_U2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldind_I4 = new OpCode(
            0xff << 0 | 0x4a << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_I4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldind_U4 = new OpCode(
            0xff << 0 | 0x4b << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_U4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldind_I8 = new OpCode(
            0xff << 0 | 0x4c << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_I8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Ldind_I = new OpCode(
            0xff << 0 | 0x4d << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_I << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldind_R4 = new OpCode(
            0xff << 0 | 0x4e << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_R4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushr4 << 24);

        public static readonly OpCode Ldind_R8 = new OpCode(
            0xff << 0 | 0x4f << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_R8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushr8 << 24);

        public static readonly OpCode Ldind_Ref = new OpCode(
            0xff << 0 | 0x50 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldind_Ref << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Stind_Ref = new OpCode(
            0xff << 0 | 0x51 << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_Ref << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stind_I1 = new OpCode(
            0xff << 0 | 0x52 << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_I1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stind_I2 = new OpCode(
            0xff << 0 | 0x53 << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_I2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stind_I4 = new OpCode(
            0xff << 0 | 0x54 << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_I4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stind_I8 = new OpCode(
            0xff << 0 | 0x55 << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_I8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi8 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stind_R4 = new OpCode(
            0xff << 0 | 0x56 << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_R4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popr4 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stind_R8 = new OpCode(
            0xff << 0 | 0x57 << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_R8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popr8 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Add = new OpCode(
            0xff << 0 | 0x58 << 8 | (byte)System.Reflection.Emit.OpCodes.Add << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Sub = new OpCode(
            0xff << 0 | 0x59 << 8 | (byte)System.Reflection.Emit.OpCodes.Sub << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Mul = new OpCode(
            0xff << 0 | 0x5a << 8 | (byte)System.Reflection.Emit.OpCodes.Mul << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Div = new OpCode(
            0xff << 0 | 0x5b << 8 | (byte)System.Reflection.Emit.OpCodes.Div << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Div_Un = new OpCode(
            0xff << 0 | 0x5c << 8 | (byte)System.Reflection.Emit.OpCodes.Div_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Rem = new OpCode(
            0xff << 0 | 0x5d << 8 | (byte)System.Reflection.Emit.OpCodes.Rem << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Rem_Un = new OpCode(
            0xff << 0 | 0x5e << 8 | (byte)System.Reflection.Emit.OpCodes.Rem_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode And = new OpCode(
            0xff << 0 | 0x5f << 8 | (byte)System.Reflection.Emit.OpCodes.And << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Or = new OpCode(
            0xff << 0 | 0x60 << 8 | (byte)System.Reflection.Emit.OpCodes.Or << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Xor = new OpCode(
            0xff << 0 | 0x61 << 8 | (byte)System.Reflection.Emit.OpCodes.Xor << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Shl = new OpCode(
            0xff << 0 | 0x62 << 8 | (byte)System.Reflection.Emit.OpCodes.Shl << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Shr = new OpCode(
            0xff << 0 | 0x63 << 8 | (byte)System.Reflection.Emit.OpCodes.Shr << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Shr_Un = new OpCode(
            0xff << 0 | 0x64 << 8 | (byte)System.Reflection.Emit.OpCodes.Shr_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Neg = new OpCode(
            0xff << 0 | 0x65 << 8 | (byte)System.Reflection.Emit.OpCodes.Neg << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Not = new OpCode(
            0xff << 0 | 0x66 << 8 | (byte)System.Reflection.Emit.OpCodes.Not << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Conv_I1 = new OpCode(
            0xff << 0 | 0x67 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_I1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_I2 = new OpCode(
            0xff << 0 | 0x68 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_I2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_I4 = new OpCode(
            0xff << 0 | 0x69 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_I4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_I8 = new OpCode(
            0xff << 0 | 0x6a << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_I8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Conv_R4 = new OpCode(
            0xff << 0 | 0x6b << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_R4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushr4 << 24);

        public static readonly OpCode Conv_R8 = new OpCode(
            0xff << 0 | 0x6c << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_R8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushr8 << 24);

        public static readonly OpCode Conv_U4 = new OpCode(
            0xff << 0 | 0x6d << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_U4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_U8 = new OpCode(
            0xff << 0 | 0x6e << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_U8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Callvirt = new OpCode(
            0xff << 0 | 0x6f << 8 | (byte)System.Reflection.Emit.OpCodes.Callvirt << 16 | (byte)FlowControl.Call << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineMethod << 8 | (byte)StackBehaviour.Varpop << 16 | (byte)StackBehaviour.Varpush << 24);

        public static readonly OpCode Cpobj = new OpCode(
            0xff << 0 | 0x70 << 8 | (byte)System.Reflection.Emit.OpCodes.Cpobj << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldobj = new OpCode(
            0xff << 0 | 0x71 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldobj << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldstr = new OpCode(
            0xff << 0 | 0x72 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldstr << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineString << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Newobj = new OpCode(
            0xff << 0 | 0x73 << 8 | (byte)System.Reflection.Emit.OpCodes.Newobj << 16 | (byte)FlowControl.Call << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineMethod << 8 | (byte)StackBehaviour.Varpop << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Castclass = new OpCode(
            0xff << 0 | 0x74 << 8 | (byte)System.Reflection.Emit.OpCodes.Castclass << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Isinst = new OpCode(
            0xff << 0 | 0x75 << 8 | (byte)System.Reflection.Emit.OpCodes.Isinst << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_R_Un = new OpCode(
            0xff << 0 | 0x76 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_R_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushr8 << 24);

        public static readonly OpCode Unbox = new OpCode(
            0xff << 0 | 0x79 << 8 | (byte)System.Reflection.Emit.OpCodes.Unbox << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Throw = new OpCode(
            0xff << 0 | 0x7a << 8 | (byte)System.Reflection.Emit.OpCodes.Throw << 16 | (byte)FlowControl.Throw << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldfld = new OpCode(
            0xff << 0 | 0x7b << 8 | (byte)System.Reflection.Emit.OpCodes.Ldfld << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineField << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldflda = new OpCode(
            0xff << 0 | 0x7c << 8 | (byte)System.Reflection.Emit.OpCodes.Ldflda << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineField << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Stfld = new OpCode(
            0xff << 0 | 0x7d << 8 | (byte)System.Reflection.Emit.OpCodes.Stfld << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineField << 8 | (byte)StackBehaviour.Popref_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldsfld = new OpCode(
            0xff << 0 | 0x7e << 8 | (byte)System.Reflection.Emit.OpCodes.Ldsfld << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineField << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldsflda = new OpCode(
            0xff << 0 | 0x7f << 8 | (byte)System.Reflection.Emit.OpCodes.Ldsflda << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineField << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Stsfld = new OpCode(
            0xff << 0 | 0x80 << 8 | (byte)System.Reflection.Emit.OpCodes.Stsfld << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineField << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stobj = new OpCode(
            0xff << 0 | 0x81 << 8 | (byte)System.Reflection.Emit.OpCodes.Stobj << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popi_pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Conv_Ovf_I1_Un = new OpCode(
            0xff << 0 | 0x82 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I1_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_I2_Un = new OpCode(
            0xff << 0 | 0x83 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I2_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_I4_Un = new OpCode(
            0xff << 0 | 0x84 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I4_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_I8_Un = new OpCode(
            0xff << 0 | 0x85 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I8_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Conv_Ovf_U1_Un = new OpCode(
            0xff << 0 | 0x86 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U1_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U2_Un = new OpCode(
            0xff << 0 | 0x87 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U2_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U4_Un = new OpCode(
            0xff << 0 | 0x88 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U4_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U8_Un = new OpCode(
            0xff << 0 | 0x89 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U8_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Conv_Ovf_I_Un = new OpCode(
            0xff << 0 | 0x8a << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U_Un = new OpCode(
            0xff << 0 | 0x8b << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Box = new OpCode(
            0xff << 0 | 0x8c << 8 | (byte)System.Reflection.Emit.OpCodes.Box << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Newarr = new OpCode(
            0xff << 0 | 0x8d << 8 | (byte)System.Reflection.Emit.OpCodes.Newarr << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Ldlen = new OpCode(
            0xff << 0 | 0x8e << 8 | (byte)System.Reflection.Emit.OpCodes.Ldlen << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelema = new OpCode(
            0xff << 0 | 0x8f << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelema << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_I1 = new OpCode(
            0xff << 0 | 0x90 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_I1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_U1 = new OpCode(
            0xff << 0 | 0x91 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_U1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_I2 = new OpCode(
            0xff << 0 | 0x92 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_I2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_U2 = new OpCode(
            0xff << 0 | 0x93 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_U2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_I4 = new OpCode(
            0xff << 0 | 0x94 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_I4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_U4 = new OpCode(
            0xff << 0 | 0x95 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_U4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_I8 = new OpCode(
            0xff << 0 | 0x96 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_I8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Ldelem_I = new OpCode(
            0xff << 0 | 0x97 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_I << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldelem_R4 = new OpCode(
            0xff << 0 | 0x98 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_R4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushr4 << 24);

        public static readonly OpCode Ldelem_R8 = new OpCode(
            0xff << 0 | 0x99 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_R8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushr8 << 24);

        public static readonly OpCode Ldelem_Ref = new OpCode(
            0xff << 0 | 0x9a << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_Ref << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Pushref << 24);

        public static readonly OpCode Stelem_I = new OpCode(
            0xff << 0 | 0x9b << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_I << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stelem_I1 = new OpCode(
            0xff << 0 | 0x9c << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_I1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stelem_I2 = new OpCode(
            0xff << 0 | 0x9d << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_I2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stelem_I4 = new OpCode(
            0xff << 0 | 0x9e << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_I4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stelem_I8 = new OpCode(
            0xff << 0 | 0x9f << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_I8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popi8 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stelem_R4 = new OpCode(
            0xff << 0 | 0xa0 << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_R4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popr4 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stelem_R8 = new OpCode(
            0xff << 0 | 0xa1 << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_R8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popr8 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stelem_Ref = new OpCode(
            0xff << 0 | 0xa2 << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_Ref << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popref_popi_popref << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldelem_Any = new OpCode(
            0xff << 0 | 0xa3 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldelem_Any << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popref_popi << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Stelem_Any = new OpCode(
            0xff << 0 | 0xa4 << 8 | (byte)System.Reflection.Emit.OpCodes.Stelem_Any << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popref_popi_popref << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Unbox_Any = new OpCode(
            0xff << 0 | 0xa5 << 8 | (byte)System.Reflection.Emit.OpCodes.Unbox_Any << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Conv_Ovf_I1 = new OpCode(
            0xff << 0 | 0xb3 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U1 = new OpCode(
            0xff << 0 | 0xb4 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_I2 = new OpCode(
            0xff << 0 | 0xb5 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U2 = new OpCode(
            0xff << 0 | 0xb6 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_I4 = new OpCode(
            0xff << 0 | 0xb7 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U4 = new OpCode(
            0xff << 0 | 0xb8 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U4 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_I8 = new OpCode(
            0xff << 0 | 0xb9 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Conv_Ovf_U8 = new OpCode(
            0xff << 0 | 0xba << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U8 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi8 << 24);

        public static readonly OpCode Refanyval = new OpCode(
            0xff << 0 | 0xc2 << 8 | (byte)System.Reflection.Emit.OpCodes.Refanyval << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ckfinite = new OpCode(
            0xff << 0 | 0xc3 << 8 | (byte)System.Reflection.Emit.OpCodes.Ckfinite << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushr8 << 24);

        public static readonly OpCode Mkrefany = new OpCode(
            0xff << 0 | 0xc6 << 8 | (byte)System.Reflection.Emit.OpCodes.Mkrefany << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldtoken = new OpCode(
            0xff << 0 | 0xd0 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldtoken << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineTok << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_U2 = new OpCode(
            0xff << 0 | 0xd1 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_U2 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_U1 = new OpCode(
            0xff << 0 | 0xd2 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_U1 << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_I = new OpCode(
            0xff << 0 | 0xd3 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_I << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_I = new OpCode(
            0xff << 0 | 0xd4 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_I << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Conv_Ovf_U = new OpCode(
            0xff << 0 | 0xd5 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_Ovf_U << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Add_Ovf = new OpCode(
            0xff << 0 | 0xd6 << 8 | (byte)System.Reflection.Emit.OpCodes.Add_Ovf << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Add_Ovf_Un = new OpCode(
            0xff << 0 | 0xd7 << 8 | (byte)System.Reflection.Emit.OpCodes.Add_Ovf_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Mul_Ovf = new OpCode(
            0xff << 0 | 0xd8 << 8 | (byte)System.Reflection.Emit.OpCodes.Mul_Ovf << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Mul_Ovf_Un = new OpCode(
            0xff << 0 | 0xd9 << 8 | (byte)System.Reflection.Emit.OpCodes.Mul_Ovf_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Sub_Ovf = new OpCode(
            0xff << 0 | 0xda << 8 | (byte)System.Reflection.Emit.OpCodes.Sub_Ovf << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Sub_Ovf_Un = new OpCode(
            0xff << 0 | 0xdb << 8 | (byte)System.Reflection.Emit.OpCodes.Sub_Ovf_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Endfinally = new OpCode(
            0xff << 0 | 0xdc << 8 | (byte)System.Reflection.Emit.OpCodes.Endfinally << 16 | (byte)FlowControl.Return << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Leave = new OpCode(
            0xff << 0 | 0xdd << 8 | (byte)System.Reflection.Emit.OpCodes.Leave << 16 | (byte)FlowControl.Branch << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineBrTarget << 8 | (byte)StackBehaviour.PopAll << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Leave_S = new OpCode(
            0xff << 0 | 0xde << 8 | (byte)System.Reflection.Emit.OpCodes.Leave_S << 16 | (byte)FlowControl.Branch << 24,
            (byte)OpCodeType.Macro << 0 | (byte)OperandType.ShortInlineBrTarget << 8 | (byte)StackBehaviour.PopAll << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Stind_I = new OpCode(
            0xff << 0 | 0xdf << 8 | (byte)System.Reflection.Emit.OpCodes.Stind_I << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Conv_U = new OpCode(
            0xff << 0 | 0xe0 << 8 | (byte)System.Reflection.Emit.OpCodes.Conv_U << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Arglist = new OpCode(
            0xfe << 0 | 0x00 << 8 | (byte)System.Reflection.Emit.OpCodes.Arglist << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ceq = new OpCode(
            0xfe << 0 | 0x01 << 8 | (byte)System.Reflection.Emit.OpCodes.Ceq << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Cgt = new OpCode(
            0xfe << 0 | 0x02 << 8 | (byte)System.Reflection.Emit.OpCodes.Cgt << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Cgt_Un = new OpCode(
            0xfe << 0 | 0x03 << 8 | (byte)System.Reflection.Emit.OpCodes.Cgt_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Clt = new OpCode(
            0xfe << 0 | 0x04 << 8 | (byte)System.Reflection.Emit.OpCodes.Clt << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Clt_Un = new OpCode(
            0xfe << 0 | 0x05 << 8 | (byte)System.Reflection.Emit.OpCodes.Clt_Un << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1_pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldftn = new OpCode(
            0xfe << 0 | 0x06 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldftn << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineMethod << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldvirtftn = new OpCode(
            0xfe << 0 | 0x07 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldvirtftn << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineMethod << 8 | (byte)StackBehaviour.Popref << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Ldarg = new OpCode(
            0xfe << 0 | 0x09 << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarg << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineArg << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldarga = new OpCode(
            0xfe << 0 | 0x0a << 8 | (byte)System.Reflection.Emit.OpCodes.Ldarga << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineArg << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Starg = new OpCode(
            0xfe << 0 | 0x0b << 8 | (byte)System.Reflection.Emit.OpCodes.Starg << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineArg << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Ldloc = new OpCode(
            0xfe << 0 | 0x0c << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloc << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineVar << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push1 << 24);

        public static readonly OpCode Ldloca = new OpCode(
            0xfe << 0 | 0x0d << 8 | (byte)System.Reflection.Emit.OpCodes.Ldloca << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineVar << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Stloc = new OpCode(
            0xfe << 0 | 0x0e << 8 | (byte)System.Reflection.Emit.OpCodes.Stloc << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineVar << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Localloc = new OpCode(
            0xfe << 0 | 0x0f << 8 | (byte)System.Reflection.Emit.OpCodes.Localloc << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Endfilter = new OpCode(
            0xfe << 0 | 0x11 << 8 | (byte)System.Reflection.Emit.OpCodes.Endfilter << 16 | (byte)FlowControl.Return << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Unaligned = new OpCode(
            0xfe << 0 | 0x12 << 8 | (byte)System.Reflection.Emit.OpCodes.Unaligned << 16 | (byte)FlowControl.Meta << 24,
            (byte)OpCodeType.Prefix << 0 | (byte)OperandType.ShortInlineI << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Volatile = new OpCode(
            0xfe << 0 | 0x13 << 8 | (byte)System.Reflection.Emit.OpCodes.Volatile << 16 | (byte)FlowControl.Meta << 24,
            (byte)OpCodeType.Prefix << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Tail = new OpCode(
            0xfe << 0 | 0x14 << 8 | (byte)System.Reflection.Emit.OpCodes.Tail << 16 | (byte)FlowControl.Meta << 24,
            (byte)OpCodeType.Prefix << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Initobj = new OpCode(
            0xfe << 0 | 0x15 << 8 | (byte)System.Reflection.Emit.OpCodes.Initobj << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Constrained = new OpCode(
            0xfe << 0 | 0x16 << 8 | (byte)System.Reflection.Emit.OpCodes.Constrained << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Prefix << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Cpblk = new OpCode(
            0xfe << 0 | 0x17 << 8 | (byte)System.Reflection.Emit.OpCodes.Cpblk << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Initblk = new OpCode(
            0xfe << 0 | 0x18 << 8 | (byte)System.Reflection.Emit.OpCodes.Initblk << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Popi_popi_popi << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode No = new OpCode(
            0xfe << 0 | 0x19 << 8 | (byte)System.Reflection.Emit.OpCodes.No << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Prefix << 0 | (byte)OperandType.ShortInlineI << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Rethrow = new OpCode(
            0xfe << 0 | 0x1a << 8 | (byte)System.Reflection.Emit.OpCodes.Rethrow << 16 | (byte)FlowControl.Throw << 24,
            (byte)OpCodeType.Objmodel << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);

        public static readonly OpCode Sizeof = new OpCode(
            0xfe << 0 | 0x1c << 8 | (byte)System.Reflection.Emit.OpCodes.Sizeof << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineType << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Refanytype = new OpCode(
            0xfe << 0 | 0x1d << 8 | (byte)System.Reflection.Emit.OpCodes.Refanytype << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Primitive << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop1 << 16 | (byte)StackBehaviour.Pushi << 24);

        public static readonly OpCode Readonly = new OpCode(
            0xfe << 0 | 0x1e << 8 | (byte)System.Reflection.Emit.OpCodes.Readonly << 16 | (byte)FlowControl.Next << 24,
            (byte)OpCodeType.Prefix << 0 | (byte)OperandType.InlineNone << 8 | (byte)StackBehaviour.Pop0 << 16 | (byte)StackBehaviour.Push0 << 24);
    }

}
