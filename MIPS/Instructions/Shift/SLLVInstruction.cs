using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SLLVInstruction : Instruction
    {
        private Register rs;
        private Register rt;
        private Register rd;

        public SLLVInstruction(Register rs,Register rt,Register rd)
        {
            this.rs = rs;
            this.rt = rt;
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("SLLV ${0},${1},${2}",rd,rt,rs);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            PSX.WriteRegister(rd,rtv << rsv);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rt);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Shl);
            c.StoreRegister(rd);
            return true;
        }
    }
}
