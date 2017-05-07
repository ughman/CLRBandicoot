using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class LWCInstruction : Instruction
    {
        private int copid;
        private Register rs;
        private int coprd;
        private int imm;

        public LWCInstruction(int copid,Register rs,int coprd,int imm)
        {
            this.copid = copid;
            this.rs = rs;
            this.coprd = coprd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("LWC{0} ${1},{3}(${2})",copid,coprd,rs,imm);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.LoadMemory32();
            c.StoreCOPData(copid,coprd);
            return true;
        }
    }
}
