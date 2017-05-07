using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class JInstruction : Instruction
    {
        private int target;

        public JInstruction(int target)
        {
            this.target = target;
        }

        public override string ToString()
        {
            return string.Format("J {0:X}",target);
        }

        public override int Execute(Instruction next)
        {
            if (next == null)
                throw new PSXException();
            next.Execute(null);
            return (PSX.PC & ~0xFFFFFFF) | target << 2;
        }

        public override void Mark(Compiler c,int address)
        {
            c.Mark((address & ~0xFFFFFFF) | target << 2);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefaultBranch(c,address,direct);
            if (!direct)
                throw new PSXException();
            Word nextword = PSX.GetWord(address + 4);
            Word branchword = PSX.GetWord((address & ~0xFFFFFFF) | target << 2);
            Disassemble(nextword.Value).Compile(c,address + 4,false);
            c.Jump(branchword);
            return false;
        }
    }
}
