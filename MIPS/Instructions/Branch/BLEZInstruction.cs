using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class BLEZInstruction : Instruction
    {
        private Register rs;
        private int offset;

        public BLEZInstruction(Register rs,int offset)
        {
            this.rs = rs;
            this.offset = offset;
        }

        public override string ToString()
        {
            return string.Format("BLEZ ${0},{1:X}",rs,offset * 4 + 4);
        }

        public override int Execute(Instruction next)
        {
            if (next == null)
                throw new PSXException();
            int rsv = PSX.ReadRegister(rs);
            if (rsv <= 0)
            {
                next.Execute(null);
                return PSX.PC + offset * 4 + 4;
            }
            else
            {
                return PSX.PC + 4;
            }
        }

        public override void Mark(Compiler c,int address)
        {
            base.Mark(c,address);
            c.Mark(address + offset * 4 + 4);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefaultBranch(c,address,direct);
            if (!direct)
                throw new PSXException();
            Word nextword = PSX.GetWord(address + 4);
            Word branchword = PSX.GetWord(address + offset * 4 + 4);
            Label label = c.IL.DefineLabel();
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4_0);
            c.IL.Emit(OpCodes.Bgt,label);
            Disassemble(nextword.Value).Compile(c,address + 4,false);
            c.Jump(branchword);
            c.IL.MarkLabel(label);
            return true;
        }
    }
}
