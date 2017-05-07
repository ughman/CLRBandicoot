using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class MFCInstruction : Instruction
    {
        private int copid;
        private Register rd;
        private int coprs;

        public MFCInstruction(int copid,Register rd,int coprs)
        {
            this.copid = copid;
            this.rd = rd;
            this.coprs = coprs;
        }

        public override string ToString()
        {
            return string.Format("MFC{0} ${1},${2}",copid,rd,coprs);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadCOPData(copid,coprs);
            c.StoreRegister(rd);
            return true;
        }
    }
}
