using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class SLLInstruction : Instruction
    {
        private Register rt;
        private Register rd;
        private int shamt;

        public SLLInstruction(Register rt,Register rd,int shamt)
        {
            this.rt = rt;
            this.rd = rd;
            this.shamt = shamt;
        }

        public override string ToString()
        {
            return string.Format("SLL ${0},${1},{2}",rd,rt,shamt);
        }

        public override int Execute(Instruction next)
        {
            int rtv = PSX.ReadRegister(rt);
            PSX.WriteRegister(rd,rtv << shamt);
            return PSX.PC + 4;
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rt);
            c.IL.Emit(OpCodes.Ldc_I4,shamt);
            c.IL.Emit(OpCodes.Shl);
            c.StoreRegister(rd);
            return true;
        }
    }
}
