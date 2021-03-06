using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class LWInstruction : Instruction
    {
        private Register rs;
        private Register rd;
        private int imm;

        public LWInstruction(Register rs,Register rd,int imm)
        {
            this.rs = rs;
            this.rd = rd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("LW ${0},{2}(${1})",rd,rs,imm);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int value = PSX.ReadMemory32(rsv + imm);
            PSX.WriteRegister(rd,value);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.LoadMemory32();
            c.StoreRegister(rd);
            return true;
        }
    }
}
