using System.Reflection.Emit;

namespace CLRBandicoot.MIPS
{
    public sealed class BLTZALInstruction : Instruction
    {
        private Register rs;
        private int offset;

        public BLTZALInstruction(Register rs,int offset)
        {
            this.rs = rs;
            this.offset = offset;
        }

        public override string ToString()
        {
            return string.Format("BLTZAL ${0},{1:X}",rs,offset * 4 + 4);
        }

        public override int Execute(Instruction next)
        {
            if (next == null)
                throw new PSXException();
            int rsv = PSX.ReadRegister(rs);
            if (rsv < 0)
            {
                next.Execute(null);
                PSX.RA = PSX.PC + 8;
                return PSX.PC + offset * 4 + 4;
            }
            else
            {
                return PSX.PC + 4;
            }
        }

        public override void Mark(Compiler c,int address)
        {
            c.Mark(address + 8);
            c.Mark(address + offset * 4 + 4);
        }

        public override bool Compile(Compiler c,int address,bool direct)
        {
            //return CompileDefaultBranch(c,address,direct);
            if (!direct)
                throw new PSXException();
            Word nextword = PSX.GetWord(address + 4);
            Word linkword = PSX.GetWord(address + 8);
            Word branchword = PSX.GetWord(address + offset * 4 + 4);
            Label label = c.IL.DefineLabel();
            c.LoadRegister(rs);
            c.IL.Emit(OpCodes.Ldc_I4_0);
            Disassemble(nextword.Value).Compile(c,address + 4,false);
            c.IL.Emit(OpCodes.Bge,label);
            c.IL.Emit(OpCodes.Ldc_I4,linkword.Address);
            c.StoreRegister(Register.RA);
            c.Jump(branchword);
            c.IL.MarkLabel(label);
            c.Jump(linkword);
            return false;
        }
    }
}
