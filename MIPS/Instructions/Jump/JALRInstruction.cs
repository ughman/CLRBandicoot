using System.Reflection.Emit;

using System;

namespace CLRBandicoot.MIPS
{
    public sealed class JALRInstruction : Instruction
    {
        private Register rs;
        private Register rd;

        public JALRInstruction(Register rs,Register rd)
        {
            this.rs = rs;
            this.rd = rd;
        }

        public override string ToString()
        {
            if (rd == Register.RA)
                return string.Format("JALR ${0}",rs);
            return string.Format("JALR ${0},${1}",rd,rs);
        }

        public override int Execute(Instruction next)
        {
            if (next == null)
                throw new PSXException();
            int rsv = PSX.ReadRegister(rs);
            next.Execute(null);
            PSX.WriteRegister(rd,PSX.PC + 8);
            return rsv;
        }

        public override void Mark(Compiler c,int address)
        {
            c.Mark(address + 8);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefaultBranch(c,address,direct);
            if (!direct)
                throw new PSXException();
            Word nextword = PSX.GetWord(address + 4);
            Word linkword = PSX.GetWord(address + 8);
            Disassemble(nextword.Value).Compile(c,address + 4,false);
            c.IL.Emit(OpCodes.Ldc_I4,linkword.Address);
            c.StoreRegister(rd);
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ret);
            return false;
        }
    }
}
