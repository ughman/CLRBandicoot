using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class DIVInstruction : Instruction
    {
        private Register rs;
        private Register rt;

        public DIVInstruction(Register rs,Register rt)
        {
            this.rs = rs;
            this.rt = rt;
        }

        public override string ToString()
        {
            return string.Format("DIV ${0},${1}",rs,rt);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            PSX.HI = rsv % rtv;
            PSX.LO = rsv / rtv;
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Rem);
            c.StoreHI();
            c.LoadRegister(rs);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Div);
            c.StoreLO();
            return true;
        }
    }
}
