using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class MFLOInstruction : Instruction
    {
        private Register rd;

        public MFLOInstruction(Register rd)
        {
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("MFLO ${0}",rd);
        }

        public override int Execute(Instruction next)
        {
            PSX.WriteRegister(rd,PSX.LO);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadLO();
            c.StoreRegister(rd);
            return true;
        }
    }
}
