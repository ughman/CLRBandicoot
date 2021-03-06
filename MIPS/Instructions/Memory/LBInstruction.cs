using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class LBInstruction : Instruction
    {
        private Register rs;
        private Register rd;
        private int imm;

        public LBInstruction(Register rs,Register rd,int imm)
        {
            this.rs = rs;
            this.rd = rd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("LB ${0},{2}(${1})",rd,rs,imm);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int value = (sbyte)PSX.ReadMemory8(rsv + imm);
            PSX.WriteRegister(rd,value);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.LoadMemory8();
            c.IL.Emit(OpCodes.Conv_I1);
            c.StoreRegister(rd);
            return true;
        }
    }
}
