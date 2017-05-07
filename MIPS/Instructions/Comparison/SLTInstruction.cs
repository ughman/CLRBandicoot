using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SLTInstruction : Instruction
    {
        private Register rs;
        private Register rt;
        private Register rd;

        public SLTInstruction(Register rs,Register rt,Register rd)
        {
            this.rs = rs;
            this.rt = rt;
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("SLT ${0},${1},${2}",rd,rs,rt);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            PSX.WriteRegister(rd,rsv < rtv ? 1 : 0);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Clt);
            c.StoreRegister(rd);
            return true;
        }
    }
}
