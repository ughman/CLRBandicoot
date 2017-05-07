using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class MFHIInstruction : Instruction
    {
        private Register rd;

        public MFHIInstruction(Register rd)
        {
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("MFHI ${0}",rd);
        }

        public override int Execute(Instruction next)
        {
            PSX.WriteRegister(rd,PSX.HI);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadHI();
            c.StoreRegister(rd);
            return true;
        }
    }
}
