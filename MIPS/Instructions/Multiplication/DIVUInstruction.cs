using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class DIVUInstruction : Instruction
    {
        private Register rs;
        private Register rt;

        public DIVUInstruction(Register rs,Register rt)
        {
            this.rs = rs;
            this.rt = rt;
        }

        public override string ToString()
        {
            return string.Format("DIVU ${0},${1}",rs,rt);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            PSX.HI = (int)((uint)rsv % (uint)rtv);
            PSX.LO = (int)((uint)rsv / (uint)rtv);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Rem_Un);
            c.StoreHI();
            c.LoadRegister(rs);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Div_Un);
            c.StoreLO();
            return true;
        }
    }
}
