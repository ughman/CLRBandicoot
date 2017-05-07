using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class MTHIInstruction : Instruction
    {
        private Register rs;

        public MTHIInstruction(Register rs)
        {
            this.rs = rs;
        }

        public override string ToString()
        {
            return string.Format("MTHI ${0}",rs);
        }

        public override int Execute(Instruction next)
        {
            PSX.HI = PSX.ReadRegister(rs);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.StoreHI();
            return true;
        }
    }
}
