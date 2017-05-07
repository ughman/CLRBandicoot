using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class MTLOInstruction : Instruction
    {
        private Register rs;

        public MTLOInstruction(Register rs)
        {
            this.rs = rs;
        }

        public override string ToString()
        {
            return string.Format("MTLO ${0}",rs);
        }

        public override int Execute(Instruction next)
        {
            PSX.LO = PSX.ReadRegister(rs);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.StoreLO();
            return true;
        }
    }
}
