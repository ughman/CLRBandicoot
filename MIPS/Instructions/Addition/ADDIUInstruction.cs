using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class ADDIUInstruction : Instruction
    {
        private Register rs;
        private Register rd;
        private int imm;

        public ADDIUInstruction(Register rs,Register rd,int imm)
        {
            this.rs = rs;
            this.rd = rd;
            this.imm = imm;
        }

        public override string ToString()
        {
            return string.Format("ADDIU ${0},${1},{2}",rd,rs,imm);
        }

        public override int Execute(Instruction next)
        {
            int rsv = PSX.ReadRegister(rs);
            PSX.WriteRegister(rd,rsv + imm);
            return PSX.PC + 4;
        }

        /*public override void Mark(Compiler c,int address)
        {
            base.Mark(c,address);
            // 49D2C
            // 8421 8421 8421 8421 8421
            // 0100 1001 1101 0010 1100
            if ((address & 0x4) != 0)
                c.Mark(address + 4);
        }*/

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefault(c,address,direct);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4,imm);
            c.IL.Emit(OpCodes.Add);
            c.StoreRegister(rd);
            return true;
        }
    }
}
