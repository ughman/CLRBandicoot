using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class InvalidInstruction : Instruction
    {
        private int value;

        public InvalidInstruction(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return string.Format("INVALID 0x{0:X8}",value);
        }

        public override int Execute(Instruction next)
        {
            throw new PSXException("Unrecognized opcode.");
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            throw new PSXException("Unrecognized opcode.");
        }
    }
}
