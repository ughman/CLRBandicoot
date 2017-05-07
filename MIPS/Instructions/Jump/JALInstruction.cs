using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class JALInstruction : Instruction
    {
        private int target;

        public JALInstruction(int target)
        {
            this.target = target;
        }

        public override string ToString()
        {
            return string.Format("JAL {0:X}",target);
        }

        public override int Execute(Instruction next)
        {
            if (next == null)
                throw new PSXException();
            next.Execute(null);
            PSX.RA = PSX.PC + 8;
            return (PSX.PC & ~0xFFFFFFF) | target << 2;
        }

        public override void Mark(Compiler c,int address)
        {
            c.Mark(address + 8);
            c.Mark((address & ~0xFFFFFFF) | target << 2);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefaultBranch(c,address,direct);
            if (!direct)
                throw new PSXException();
            Word nextword = PSX.GetWord(address + 4);
            Word linkword = PSX.GetWord(address + 8);
            Word branchword = PSX.GetWord((address & ~0xFFFFFFF) | target << 2);
            Disassemble(nextword.Value).Compile(c,address + 4,false);
            c.IL.Emit(OpCodes.Ldc_I4,linkword.Address);
            c.StoreRegister(Register.RA);
            //c.Jump(branchword);
            // --
            c.IL.Emit(OpCodes.Ldc_I4,branchword.Address);
            c.IL.Emit(OpCodes.Call,typeof(PSX).GetMethod("Invoke"));
            c.Jump(linkword);
            // --
            return false;
        }
    }
}
