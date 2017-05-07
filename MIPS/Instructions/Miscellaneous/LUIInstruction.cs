using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class LUIInstruction : Instruction
    {
        private Register rd;
        private int imm;

        public LUIInstruction(Register rd,int imm)
        {
            this.rd = rd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("LUI ${0},{1}",rd,imm);
        }

        public override int Execute(Instruction next)
        {
            PSX.WriteRegister(rd,imm << 16);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.IL.Emit(OpCodes.Ldc_I4,imm << 16);
            c.StoreRegister(rd);
            return true;
        }
    }
}
