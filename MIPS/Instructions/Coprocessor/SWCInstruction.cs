using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SWCInstruction : Instruction
    {
        private int copid;
        private Register rs;
        private int coprt;
        private int imm;

        public SWCInstruction(int copid,Register rs,int coprt,int imm)
        {
            this.copid = copid;
            this.rs = rs;
            this.coprt = coprt;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("SWC{0} ${1},{3}(${2})",copid,coprt,rs,imm);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.LoadCOPData(copid,coprt);
            c.StoreMemory32();
            return true;
        }
    }
}
