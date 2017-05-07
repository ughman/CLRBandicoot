using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class BREAKInstruction : Instruction
    {
        private int func;

        public BREAKInstruction(int func)
        {
            this.func = func;
        }

        public override string ToString()
        {
            return string.Format("BREAK {0}",func);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            return true;
        }
    }
}
