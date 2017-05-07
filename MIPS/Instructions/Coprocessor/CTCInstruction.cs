using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class CTCInstruction : Instruction
    {
        private int copid;
        private Register rs;
        private int coprd;

        public CTCInstruction(int copid,Register rs,int coprd)
        {
            this.copid = copid;
            this.rs = rs;
            this.coprd = coprd;
        }

        public override string ToString()
        {
            return string.Format("CTC{0} ${1},${2}",copid,rs,coprd);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.StoreCOPControl(copid,coprd);
            return true;
        }
    }
}
