using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SYSCALLInstruction : Instruction
    {
        private int func;

        public SYSCALLInstruction(int func)
        {
            this.func = func;
        }

        public override string ToString()
        {
            return string.Format("SYSCALL {0}",func);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            c.IL.Emit(OpCodes.Ldc_I4,address);
            c.IL.Emit(OpCodes.Call,typeof(PCSX).GetMethod("Syscall"));
            return true;
        }
    }
}
