using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class COPInstruction : Instruction
    {
        private int copid;
        private int copargs;

        public COPInstruction(int copid,int copargs)
        {
            this.copid = copid;
            this.copargs = copargs;
        }

        public override string ToString()
        {
            return string.Format("COP{0} 0x{1:X7}",copid,copargs);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.InvokeCOP(copid,copargs);
            return true;
        }
    }
}
