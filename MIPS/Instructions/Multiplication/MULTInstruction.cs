using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class MULTInstruction : Instruction
    {
        private Register rs;
        private Register rt;

        public MULTInstruction(Register rs,Register rt)
        {
            this.rs = rs;
            this.rt = rt;
        }

        public override string ToString()
        {
            return string.Format("MULT ${0},${1}",rs,rt);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int rtv = PSX.ReadRegister(rt);
            long result = (long)rsv * (long)rtv;
            PSX.HI = (int)(result >> 32);
            PSX.LO = (int)result;
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Conv_I8);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Conv_I8);
            c.IL.Emit(OpCodes.Mul);
            c.IL.Emit(OpCodes.Dup);
            c.IL.Emit(OpCodes.Ldc_I4,32);
            c.IL.Emit(OpCodes.Shr);
            c.IL.Emit(OpCodes.Conv_I4);
            c.StoreHI();
            c.IL.Emit(OpCodes.Conv_I4);
            c.StoreLO();
            return true;
        }
    }
}
