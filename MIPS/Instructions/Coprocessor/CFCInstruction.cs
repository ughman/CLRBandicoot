using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class CFCInstruction : Instruction
    {
        private int copid;
        private Register rd;
        private int coprs;

        public CFCInstruction(int copid,Register rd,int coprs)
        {
            this.copid = copid;
            this.rd = rd;
            this.coprs = coprs;
        }

        public override string ToString()
        {
            return string.Format("CFC{0} ${1},${2}",copid,rd,coprs);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadCOPControl(copid,coprs);
            c.StoreRegister(rd);
            return true;
        }
    }
}
