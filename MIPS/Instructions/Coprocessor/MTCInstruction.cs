using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class MTCInstruction : Instruction
    {
        private int copid;
        private Register rs;
        private int coprd;

        public MTCInstruction(int copid,Register rs,int coprd)
        {
            this.copid = copid;
            this.rs = rs;
            this.coprd = coprd;
        }

        public override string ToString()
        {
            return string.Format("MTC{0} ${1},${2}",copid,rs,coprd);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.StoreCOPData(copid,coprd);
            return true;
        }
    }
}
