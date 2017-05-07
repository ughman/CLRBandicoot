using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SLTIUInstruction : Instruction
    {
        private Register rs;
        private Register rd;
        private int imm;

        public SLTIUInstruction(Register rs,Register rd,int imm)
        {
            this.rs = rs;
            this.rd = rd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("SLTIU ${0},${1},{2}",rd,rs,imm);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            PSX.WriteRegister(rd,(uint)rsv < imm ? 1 : 0);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Clt_Un);
            c.StoreRegister(rd);
            return true;
        }
    }
}
