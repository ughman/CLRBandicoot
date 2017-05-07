using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class LHUInstruction : Instruction
    {
        private Register rs;
        private Register rd;
        private int imm;

        public LHUInstruction(Register rs,Register rd,int imm)
        {
            this.rs = rs;
            this.rd = rd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("LHU ${0},{2}(${1})",rd,rs,imm);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            int value = (ushort)PSX.ReadMemory16(rsv + imm);
            PSX.WriteRegister(rd,value);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.LoadMemory16();
            c.IL.Emit(OpCodes.Conv_U2);
            c.StoreRegister(rd);
            return true;
        }
    }
}
