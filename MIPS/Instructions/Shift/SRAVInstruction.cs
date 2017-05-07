using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SRAVInstruction : Instruction
    {
        private Register rs;
        private Register rt;
        private Register rd;

        public SRAVInstruction(Register rs,Register rt,Register rd)
        {
            this.rs = rs;
            this.rt = rt;
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("SRAV ${0},${1},${2}",rd,rt,rs);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            PSX.WriteRegister(rd,rtv >> rsv);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rt);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Shr);
            c.StoreRegister(rd);
            return true;
        }
    }
}
