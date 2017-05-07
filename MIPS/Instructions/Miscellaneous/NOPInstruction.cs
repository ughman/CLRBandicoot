using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class NOPInstruction : Instruction
    {
        public override string ToString()
        {
            return "NOP";
        }

        public override int Execute(Instruction next)
        {
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            return true;
        }
    }
}
