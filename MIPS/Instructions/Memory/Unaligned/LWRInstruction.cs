using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class LWRInstruction : Instruction
    {
        private Register rs;
        private Register rd;
        private int imm;

        public LWRInstruction(Register rs,Register rd,int imm)
        {
            this.rs = rs;
            this.rd = rd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("LWR ${0},{2}(${1})",rd,rs,imm);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.IL.Emit(OpCodes.Dup);
            c.IL.Emit(OpCodes.Ldc_I4_3);
            c.IL.Emit(OpCodes.And);
            c.IL.Emit(OpCodes.Ldc_I4_3);
            c.IL.Emit(OpCodes.Shl);
            c.IL.Emit(OpCodes.Stloc_1);
            c.IL.Emit(OpCodes.Ldc_I4,~3);
            c.IL.Emit(OpCodes.And);
            c.IL.Emit(OpCodes.Stloc_0);
            c.LoadRegister(rd);
            c.IL.Emit(OpCodes.Ldc_I4_M1);
            c.IL.Emit(OpCodes.Ldloc_1);
            c.IL.Emit(OpCodes.Shr_Un);
            c.IL.Emit(OpCodes.Not);
            c.IL.Emit(OpCodes.And);
            c.IL.Emit(OpCodes.Ldloc_0);
            c.LoadMemory32();
            c.IL.Emit(OpCodes.Ldloc_1);
            c.IL.Emit(OpCodes.Shr_Un);
            c.IL.Emit(OpCodes.Or);
            c.StoreRegister(rd);
            return true;
        }
    }
}
