using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SWRInstruction : Instruction
    {
        private Register rs;
        private Register rt;
        private int imm;

        public SWRInstruction(Register rs,Register rt,int imm)
        {
            this.rs = rs;
            this.rt = rt;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("SWR ${0},{2}(${1})",rt,rs,imm);
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
            c.IL.Emit(OpCodes.Dup);
            c.LoadMemory32();
            c.IL.Emit(OpCodes.Ldc_I4_M1);
            c.IL.Emit(OpCodes.Ldloc_1);
            c.IL.Emit(OpCodes.Shl);
            c.IL.Emit(OpCodes.Not);
            c.IL.Emit(OpCodes.And);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Ldloc_1);
            c.IL.Emit(OpCodes.Shl);
            c.IL.Emit(OpCodes.Or);
            c.StoreMemory32();
            return true;
        }
    }
}
